export BaseAdts=(link node BT BST linklist dlink dnode dBT dBST dlinklist)
export BaseAdts=(ADTs)
# echo ${BaseAdts[*]}

for base in ${BaseAdts[*]}
do 
    echo "================================ Generating  $base ================================"
    if [ ! -d "./$base" ]
    then
        dotnet new classlib -o "$base"
        dotnet new xunit3 -o "$base.test"
        dotnet add "./$base.test/$base.test.csproj" reference "./$base/$base.csproj" 
        dotnet sln ADTs.sln add "./$base/$base.csproj" "./$base.test/$base.test.csproj"
        mv -v "./$base/Class1.cs" "./$base/$base.cs"
        mv -v "./$base.test/UnitTest1.cs" "./$base.test/${base}Test.cs"
    else
        echo "    --> folder ./$base already exists"
    fi
    echo "================================ Done  with  $base ================================"
done

echo "********************************      Finished     ********************************"

