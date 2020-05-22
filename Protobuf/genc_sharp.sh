#!/usr/bin/env bash
#產生對應物件
echo "請輸入欲產生的檔案proto名稱,不包含副檔名.proto"
  
read protoname

echo "請輸入js 或是 c# 確定產出格式"
read type

work_path=$(pwd)
if [[ ${type} = "c#" ]]
then
    protoc -I ${work_path}/ProtoFile/ --csharp_out=${work_path}/C_Sharp ${protoname}.proto
    echo "C# class 已完成"
elif [[ ${type} = "js" ]]
then
    #產出在Nodejs上能夠直接讀取得格式
    protoc -I=${work_path}/ProtoFile/  --js_out=import_style=commonjs,binary:${work_path}/JS/  ${protoname}.proto
   
    #透過browserify將JS轉為網頁能夠直接讀取的格式
    browserify  ${work_path}/JS/${protoname}_pb.js > ${work_path}/JS/${protoname}_client.js
    echo "Js 已完成"
else
    echo "輸入類型錯誤"
fi
