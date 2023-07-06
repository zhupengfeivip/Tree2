# Tree2
生成目录树的命令

命令


tree2.exe 参数1 参数2 参数3

第一个参数为路径
第二个参数为最大深度
第三个为输出类型 1为tree，2为md表格

```
tree2.exe D:\.netsource\Tree2 3 1

|Tree2
|__images
|__Tree2

```

```
tree2.exe D:\.netsource\Tree2 3 2
```


|Name              | Description       |
|------------------|-------------------|
|Tree2              |       |
|__images              |       |
|__Tree2              |主程序       |



# 文件说明
.treeignore 
存放忽略的文件夹，在根目录下存放即可


.treeattributes
存放于各目录下，用于标识目录的功能说明
目前有两行
第一行为版本号，目前为1
第二行为文件夹描述

# 功能说明
支持自动读取java的pom.xml中的Description字段。
