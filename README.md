Manager of Managers 框架
========================
#简介
Unity3D框架有简单的EmptyGO，Simple GameManager，不过这两种应付小型游戏还可以，面对中大型游戏，前面两种设计模式的代码耦合性过高，会导致项目在中后期进展慢，麻烦事多，bug隐患大。Manager Of Managers指将不同功能的模块分别设计成一个Manager作为管理，模块之间再各自进行通讯，有较强的解耦合性，使得项目思路更为清晰。<br>
此项目是自己摸索着学习的过程中写的框架，目的当然是为了以后做东西的时候方便点啦~当然框架并不完善，日后慢慢补充。
#开发逻辑
采用MVP的设计模式，分离成GameObject, Presenter, Model三层。<br>

#所包含的Managers
##.UIManager
对UI进行管理
##2.GameManager
对游戏状态和场景进行管理,包含加载场景
##3.PoolManager
对缓存池的管理
##4.SaveManager
对游戏数据存储的管理
##5.ApiManager
对网络请求的管理
##6.TaskManager
对协程进行管理

#所包含的工具类
1.XMLHelper,XML解析和构造<br>
2.JsonHelper,Json解析和构造<br>


