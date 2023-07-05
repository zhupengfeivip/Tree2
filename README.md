# Tree2
生成目录树的命令

命令


tree2.exe 参数1 参数2 参数3

第一个参数为路径
第二个参数为最大深度
第三个为输出类型 1为tree，2为md表格

tree2.exe D:\.netsource\Tree2 3 1

|Tree2
|__images
|__Tree2


tree2.exe D:\.netsource\Tree2 3 2

|Name              | Description       |
|------------------|-------------------|
|Tree2              |       |
|__images              |       |
|__Tree2              |主程序       |