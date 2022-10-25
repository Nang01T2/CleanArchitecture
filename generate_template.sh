#!/usr/bin/env bash

# This is a shell script to transform the PRODUCTNAME directory into a cookie-cutter template

# Environmental variable options accepted by `generate_template.sh`:

# * `VERBOSE=true`: Prints more verbose output.
# * `SKIP_REGENERATION=true`: Does not alter the generated cookiecutter template.
# * `SKIP_TESTS=true`: Does not perform tests after generating template.
# * `KEEP_COOKIECUTTER_OUTPUT=true`: Do not delete cookiecutter output after running tests (final output is in `ProjectName` directory).
# * `OUTPUT_DIR`: Use a different output directory (default is current directory)


# Delete files that we don't want to include in the template
rm -rf CleanArchitecture/CleanArchitecture.Domain/bin
rm -rf CleanArchitecture/CleanArchitecture.Domain/obj
rm -rf CleanArchitecture/CleanArchitecture.Application/bin
rm -rf CleanArchitecture/CleanArchitecture.Application/obj
rm -rf CleanArchitecture/CleanArchitecture.Application.UnitTests/bin
rm -rf CleanArchitecture/CleanArchitecture.Application.UnitTests/obj
rm -rf CleanArchitecture/CleanArchitecture.Infrastructure/bin
rm -rf CleanArchitecture/CleanArchitecture.Infrastructure/obj
rm -rf CleanArchitecture/CleanArchitecture.Persistence/bin
rm -rf CleanArchitecture/CleanArchitecture.Persistence/obj
rm -rf CleanArchitecture/CleanArchitecture.Identity/bin
rm -rf CleanArchitecture/CleanArchitecture.Identity/obj
rm -rf CleanArchitecture/CleanArchitecture.Api/bin
rm -rf CleanArchitecture/CleanArchitecture.Api/obj
rm -rf CleanArchitecture/CleanArchitecture.AzureFunction/bin
rm -rf CleanArchitecture/CleanArchitecture.AzureFunction/obj
rm -rf CleanArchitecture/CleanArchitecture.MVC/bin
rm -rf CleanArchitecture/CleanArchitecture.MVC/obj

set -e
set -o pipefail

# Run this script in its own directory
SCRIPT_DIR="$(dirname $0)"
cd $SCRIPT_DIR

echo "Regenerating cookiecutter template from CleanArchitecture directory contents..."

#This is the only lookup that is done on filenames
LOOKUP="CleanArchitecture"
EXPANDED="{{ cookiecutter.projectName }}"
LOOKUPDIR="CleanArchitecture"
EXPANDEDDIR="{{ cookiecutter.assembly_name }}"

if [ ! -z "$OUTPUT_DIR" ] ; then
    echo "Using output directory: $OUTPUT_DIR"
    mkdir $OUTPUT_DIR
    cp -rf "$LOOKUP" "$OUTPUT_DIR/$LOOKUP"
    cp cookiecutter.json "$OUTPUT_DIR/"
    if [ "${SKIP_REGENERATION}" == "true" ] ; then
        cp -rf "$EXPANDED" "$OUTPUT_DIR/$EXPANDED" 
    fi
    cd $OUTPUT_DIR
fi

# Clear out any left over artifacts from last regeneration
if [ "${SKIP_REGENERATION}" != "true" ] ; then
    echo "Deleting old template output..."
    rm -rf "${EXPANDED}/"
    echo "Regenerating template..."
else
    echo "Performing dry run on existing template output..."
fi

# Make the tree
find ./CleanArchitecture -type d | while read FILE
do
    NEWFILE1=`echo $FILE | sed -e "s/${LOOKUPDIR}/${EXPANDEDDIR}/g"`
    NEWFILE2=`echo $NEWFILE1 | sed -e "s/${LOOKUP}/${EXPANDED}/g"`
    MKDIR_CMD="mkdir -p \"$NEWFILE2\""
    
    if [ "${VERBOSE}" == "true" ] ; then
        echo "${MKDIR_CMD}"
    fi
    if [ "${SKIP_REGENERATION}" != "true" ] ; then
        eval $MKDIR_CMD
    fi
done

# Copy the files over
find ./CleanArchitecture -type f | while read FILE
do
    NEWFILE1=`echo $FILE | sed -e "s/${LOOKUPDIR}/${EXPANDEDDIR}/g"`
    NEWFILE=`echo $NEWFILE1 | sed -e "s/${LOOKUP}/${EXPANDED}/g"`
    COPY_CMD="cp \"$FILE\" \"$NEWFILE\""
    if [ "${VERBOSE}" == "true" ] ; then
        echo "${COPY_CMD}"
    fi
    if [ "${SKIP_REGENERATION}" != "true" ] ; then
        eval $COPY_CMD
    fi
done

# Do replacements
function replace {
    grep -rl $1 ./CleanArchitecture | while read FILE
    do 
    NEWFILE1=`echo $FILE | sed -e "s/${LOOKUPDIR}/${EXPANDEDDIR}/g"`
    NEWFILE=`echo $NEWFILE1 | sed -e "s/${LOOKUP}/${EXPANDED}/g"`
        SED_CMD="LC_ALL=C sed -e \"s/$1/$2/g\" \"$NEWFILE\" > t1 && mv t1 \"$NEWFILE\""
        # Copy over incase the sed fails due to encoding
        #echo "echo \"$FILE\""
        if [ "${VERBOSE}" == "true" ] ; then
            echo "${SED_CMD}"
        fi
        if [ "${SKIP_REGENERATION}" != "true" ] ; then
            eval $SED_CMD
        fi        
    done
}

replace "CleanArchitecture" "{{ cookiecutter.assembly_name }}"
# replace "ORGANIZATION" "{{ cookiecutter.companyName }}"
# replace "AUTHOR" "{{ cookiecutter.author }}"
# replace "DATE" "{{ cookiecutter.date }}"
# replace "com.company.PRODUCTNAME" "{{ cookiecutter.bundleIdentifier }}"
