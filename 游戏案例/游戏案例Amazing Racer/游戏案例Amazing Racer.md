# 游戏案例Amazing Racer

## 设计

### 理念

从一个游戏区域跑到另一边，前进的道路上会出现山丘、树木和各种障碍物。

### 规则

* 没有胜利或者失败，只有完成条件。当玩家进入完成区域即完成游戏。
* 玩家总是在相同的地点出生，完成区域也总是在相同的地点。
* 途中会出现水障碍。每当玩家陷入水障碍中，都会把该玩家移动到出生点（spawn point）
* 游戏的目标是尽量用最短的时间从地图这边跑到那边。

### 需求

* 一块矩形区域的地形。地形要够大，包含一些障碍物。出生点和重点。
* 地形的纹理和环境效果。使用标准资源。
* 一个出生点对象、一个完成区域对象和一个水障碍对象。
* 一个角色控制器。
* 一个图形用户界面（GUI）
* 一个游戏控制器。



## 创建游戏世界

### 制作地形

* 创建新项目Amazing Racer。在项目中添加一个地形，在Inspector中设置为（0，0，0）
* 在第6张找到TerrainHeightMap.raw，导入文件
* 保持Depth、Width、Height这些属性不变，将Byte Order属性改为Mac，将Terrain的大小改为200宽、100场，以及100高
* 在Assets文件夹下创建一个Scenes文件夹，将当前场景保存为Main



### 添加环境

* 按照喜好调整定向光的旋转角度
* 纹理化地形。示例项目使用以下纹理：平台的区域使用GrassHillAlbedo，陡峭的区域使用CliffAlbedoSpecular，他们之间的区域使用GrassRockyAlbedo。水坑内使用MudRockyAlbedoSpecular
* 在地形中添加一些树木。树木应该保持稀疏，主要放在平坦的地面上
* 向场景中添加一些水资源，在Assets\Standard Assets\Environment\Water\Water4\Prefabs文件夹找到Water4Advanced这个预设，将位置设置为（100，29，100）缩放大小设置为（2，1，2）



### 雾效

可以使用大雾来营造一种陌生的感觉，可以使用雾效遮挡远处的地形，为游戏增加一定的趣味性

* Window>Rendering>Lighting Settings打开光设置窗口
* 在其他Other设置中勾选雾效
* 将颜色改为白色，稠密度改为0.005

### 天空盒

你可以通过给与世界添加一个天空盒增加渲染力，他就是一个保卫游戏世界的大盒子。

标准天空盒为Procedural skybox。

* 在Project视图中右键单击，选择Create>Material命令
* 在新材质的Inspector中，选择Shader下拉框，选择Skybox>Procedural。当然你也可以选择6Sided、CubeMap或者Panoranmic这些类型的天空盒。
* 在Lighting的设置（Window>Rendering>Lighting Settings）将天空盒应用于场景。同样，你也可以将天空盒材质拖动到场景视图的空间上。将天空盒应用到场景的时候，你无法立刻看到效果。
* 尝试修改天空盒的各种参数。比如太阳的外观、大气中散射的光线，天空盒颜色等等。



### 角色控制器

* Assets>Import Package>Characters导入标准的角色控制器
* 在Assets\Standard Assets\Characters\FirstPersonCharacter\Prefabs文件夹下找到FPSController这个资源，拖到场景中
* 设置控制器的位置。（0，0，0），将控制器按照y轴旋转260度，命名为Player
* 因为Player有自己的摄像机，所以需要将场景中的Main Camera删除



## 游戏化

游戏化Gamification。需要添加一些脚本把他们串联到一起。

### 添加游戏控制对象

* 向场景中添加一个空的游戏对象
  * GameObject>Create Empty
* 将游戏对象放在（160，32，125）的位置处，然后将旋转角度改为（0，260，0）
* 在Hierarchy视图中将空对象重命名为Spawn Point

接下来创建水障碍检测器。它是一个位于睡眠之下的简单平面，他有一个触发碰撞器，用于检测玩家是否落入水中。

* 向场景中添加一个平面
  * GameObject>3DObject>Plane命令
  * 将他置于（100，27，100）处，然后将缩放比例改为（20，1，20）
* 然后在Hierarchy视图中把平面重命名为Water Hazard Detector
* 在Inspector视图中选择Mesh Collider组件，然后勾选Convex和Is Trigger这两个选项。
* 不要勾选INspector中的Mesh Render组件名字前面的复选框。这样就会禁用Mesh Render对象，游戏内将不会看到这个对象。

接下来添加游戏完成区域，这个区域是一个简单的对象，他上边有一个点光源，让玩家知道去哪里。该对象有一个胶囊体（capsule collider）他可以让我们知道玩家何时可以进入该区域。要添加Finish Zone对象，可以按照如下步骤操作。

* 向场景中添加一个空的游戏对象，将他的位置放在（26，32，37）处
* 在Hierarchy视图中将该对象重命名为Finish Zone
* 在FinishZone对象上添加一个灯光组件
  * Component>Rendering>Light
  * 如果他的类型还不是Point，将灯光类型改为Point，然后把范围和强度分别设置为35和3
* 选中Finish Zone对象，然后使用
  * Component>Physics>Capsule Collider
  * 给该对象添加一个胶囊体。在Inspector中勾选IsTrigger复选框，然后把Radius属性设置为9

最后需要创建的事Game Manager对象。从技术上讲不需要这个对象，在游戏世界里一直存在的对象上添加上对应的属性即可。比如Main Camera。

不过一般都会创建一个单独的对象，后边会用到。

* 在场景中添加一个空对象
* 在Hierarchy视图中将对象命名为Game Manager



### 添加脚本

创建脚本的两种方式：

* 将已经存在的脚本拖入到项目视图中
* 在Project右键点击，选择Create>C#Script

使用非常简单，只需要将脚本拖动到应用他的对象上即可。

* 将Hour 6中找到三个脚本并导入
* 将FinshZone.cs拖动到Finish Zone
* 将Game Manager选择（另一种方法）
  * Add Component>Scripts>GameManager
* 将PlayerRespawn脚本拖动到Water Hazard Detector

> 可能你会注意到，Project视图中的GameManager脚本有一个齿轮形状的图标，这是因为脚本有一个Unity可以自动识别的名字GameManager。有一些特殊的名字应用在脚本上的时候，图标就会发生变化，让我们更容易区分。



### 将脚本连在一起

* 选中Detector对象，Player Respawn组件上有一个GameManager属性
* 拖动GameManager对象将他拖动到Player Respawn组件的GameMangaer上（这样玩家落水的时候就会通知GameManager）
* 选中Finish Zone，将GameMangaer拖动到FinishZone的GameManager组件上
* SpawnPoint同上
* 点击并拖动Player对象，将他放到GameManager的Player属性上

可以测试了。



## 游戏测试





## 其他

