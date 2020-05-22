## netcore 3.1 WebSockek + protobuf 

### 專案結構說明
##### Protobuf:主要是產生websockek與client之間的傳輸格式
* 透過genc_sharp.sh(for linux　env)產出對應程式語言的定義檔案,目前只有JS 跟 C#
* 需安裝 https://github.com/protocolbuffers/protobuf/releases

##### SignalrServier :
* 目前測試通訊實作有三種 廣播,私下訊息,取得線上人數與清單.程式實作位置:Services\Chat
* 加入Redis 做為 Backplane

##### WebSocketServer :
* 目前測試通訊實作有三種 廣播,私下訊息,取得線上人數與清單.程式實作位置:Events\Chat
* 入口點在Startup.cs 行數在37~78

##### WebScoketClient :測試Sokcet的前端網頁
