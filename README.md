﻿# chu_core_webapi

***RESTful API is***
---

REST 是一種軟體架構樣式，以下是 REST API 遵循的六項原則：

**1. 用戶端-伺服器架構**
: 傳送者和接收者在技術、平台化、程式設計語言等方面彼此獨立。

**2. 分層**
: 伺服器可以有多個中繼協作完成用戶端請求，但它們對客戶來說是不可見的。

**3. 統一介面**
: API 會以完整且可完全使用的標準格式傳回資料。

**4. 無狀態**
: API 會完成每個新要求，與之前的請求無關。

**5. 可快取**
: 所有 API 回應都可以快取。

**6. 隨需編碼**
: 如有需要，API 回應可包含程式碼片段。


***Resources in REST***
---
指的是網路上的一個實體或是一個具體的訊息。可以是一段文字、圖片、歌曲或是服務。在網路程式中，你可以透過網址（URL）指向資源並取得資源，每一種資源對應一個特定的URL。
- 可以使用 GET 和 POST 等 HTTP 動詞來傳送 REST 請求。
- REST API 回應通常採用 JSON 格式，但也可以是不同的資料格式。
- 在REST中，Resources是重要的觀念，操作資源的過程中，我們可以透過HTTP這個標準進行溝通。應用程式不需要了解Server中的資訊，只需要知道資源的表現(representation)是什麼。



***SOAP  VS  REST***
---

| SOAP | REST | 
|:--: |:--:|
| 一種協定  | 一種架構樣式 | 
| 方法高度結構化 | 靈活度高 | 
| 使用 XML 資料格式  |允許應用程式以多種格式交換資料  | 
| 私有 API。可會受益於 WS-Security 中更嚴格的安全措施 | 公有API |
