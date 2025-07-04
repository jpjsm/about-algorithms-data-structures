export BaseAdts=(link node BT BST)

# echo ${BaseAdts[*]}

for base in ${BaseAdts[*]}
do 
    mv -v "./$base.test/UnitTest1.cs" "./$base.test/${base}Test.cs"
done