# -小白书店管理系统
根据B站教程学习写的第一个程序(【书店管理系统设计与开发   Visual Studio   C#   SQL Server】 https://www.bilibili.com/video/BV1xP411n7NV/?share_source=copy_web&vd_source=373e63173e5bec4c37833fcfb6460f93)
#
与视频相比增加了购物车的删除且删除后书籍能够返回库存
#
直接连接数据库，通过以下代码：

private static string appPath = AppDomain.CurrentDomain.BaseDirectory;//当前执行文件的目录

private static string fileName = "BookStore.mdf";//目录下的数据库文件

private static string filePath = Path.Combine(appPath, fileName);//数据库路径

SqlConnection con = new SqlConnection($@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={filePath};Integrated Security=True;Connect Timeout=30;Encrypt=False");

并且打包了应用程序进行安装
