隨意桌面 數位溝通

背景概述

在行動裝置和數位家庭娛樂的旋風席捲全球下，人與人之間透過網路溝通的機會也大幅度的提升；MSN Messenger、Skype等即時通訊軟體提供豐富和多樣性的需求，從單純的文字傳訊到語音聊天和最後的視訊會議，清楚地突顯出一種重要的概念－「數位溝通」。

在視訊會議普及的數位時代中，人們目前依然停留在人與人之間的溝通與互動，對於人與人和電腦之間的三方溝通缺乏有效的機制，也就是說人們無法透過眼前電腦螢幕的表現即時的告訴遠在另一端的朋友，像是會議簡報內容、行車電子地圖、軟體操作等；因此要是有一個「隨意桌面」的概念讓這樣的理想實現，那數位溝通將更能具體實現遠大的一句話：「電腦將無所不在」。

軟體導覽

為了在數位時代實現數位溝通的理想，為了在網路世界創造隨意桌面的情境，本軟體運用新一代 Microsoft .NET 2.0 解決方案實現「隨意桌面，數位溝通」的理想，透過群組會議進行將桌面、視訊和語音一次雙向的傳送給所有的群組成員，運用 TCP Socket、DirectSound 和 InteropServices 技術讓數位溝通無遠弗屆。其中，TCP Socket 傳送/接收序列化  串流資料，DirectSound 提供語音錄製/播放功能，InteropServices 連接 Win32 API 和 COM 元件將桌面序列化傳送。

本軟體實現「隨意桌面，數位溝通」中創造了前所未見的數位時代溝通模式，人們可以視桌面為個人在網路上溝通的代理人，無論是在家、學校或是出外工作，皆可以隨時隨地的傳送您的代理人。在現今寬頻網路普及下，本軟體對於頻寬的限制亦相當重視，在隨意桌面傳送過程，平均每秒只需要 30 KBytes，這是因為本軟體實作螢幕比對、畫面壓縮和語音壓縮等技術，意味著「隨意桌面，數位溝通」的可行性、創新性和未來性。

TCP Socket

使用 System.Net.Sockets.TcpListener 傾聽串流伺服器連接埠，運用封包轉送原理將用戶端欲傳送的隨意桌面畫面轉送給邀請的另一個用戶端，即不需考慮兩地之間的防火牆限制。在畫面傳送時，撰寫 System.Net.Sockets.Socket 動態地產生序列化物件，接收桌面和語音原始 byte 陣列，並使用System.Net.Sockets.NetworkStream 進行物件序列化，物件序列化使用 System.Runtime.Serialization.Formatters.Binary.BinaryFormatter。為了有效地減少資料量，本軟體撰寫螢幕比對原理和畫面及語音的壓縮，使隨意桌面在傳送期間，每秒平均為 30 KBytes，符合寬頻網路需求。

在螢幕比對原理為將螢幕緩衝的畫面以System.Drawing.Bitmap物件觀看，然後取出System.Drawing.Imaging.BitmapData，隨即可取得一維原始 byte 陣列，並根據 Bitmap 影像規格 BGR 原理進行比對。首先先取得一張比對依據影像，接下來取得的影像和前一張比對，相同的 byte 設為0。對於每一張影像的 byte 陣列採用 System.IO.Compression.GZip 壓縮；在另一端取得影像後，根據前一張完整影像進行影像重建，其減少傳送頻寬資料原理即相同 byte 設為 0 時，使用 GZip 即可有效地減少資料的儲存。在語音的壓縮亦使用 GZip 進行壓縮。

DirectSound

採用 Microsoft.DirectX.DirectSound.CaptureBuffer 取得語音緩衝，Microsoft.DirectX.DirectSound.SecondaryBuffer進行語音播放，CaptureBuffer 和 SecondaryBuffer 採用環狀緩衝方式實作，也就是說緩衝區為一固定大小，而存在二個指標，一個指向當前讀取/寫入的位置，另一個指向下一次寫入/讀取的位置，當抵達緩衝區結尾時即回到緩衝區開頭。

由於緩衝必需由其他執行緒取得，在即時資料傳送時必需使用 Microsoft.DirectX.DirectSound.Notify 和Microsoft.DirectX.DirectSound. BufferPositionNotify，透過定位 CaptureBuffer/SecondaryBuffer 緩衝區在讀取/寫入第 n 個索引時進進行執行緒回呼，並定義回呼方法。

InteropService

透過 System.Runtime.InteropServices.DllImport 定義呼叫 Win32 API 的靜態方法，其中 GetDesktopWindow()、GetDC() 為取得桌面獨一無二 Handle，根據 CreateCompatibleDC()、CreateCompatibleBitmap() 將 Handle 所指向的螢幕緩衝區轉換成 HBitmap 指標，最後透過 System.Drawing.Graphics 將 HBitmap 轉換成 System.Drawing.Bitmap物件，完成螢幕緩衝取得。

全國競賽

本軟體榮獲 2006 微軟潛能創意盃台灣區軟體設計組 第三名。
