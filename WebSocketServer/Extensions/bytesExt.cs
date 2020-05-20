using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace WebSocketServer.Extensions
{
    public static class bytesExt
    {
        /// <summary>
        /// 轉換由client 透過 web 傳過來的prtobuf二進位檔案
        /// </summary>
        /// <param name="buffer"></param>
        /// <param name="cnt"></param>
        /// <returns></returns>
        public static async Task<Stream> ConvertToStreamAsync(this ArraySegment<byte> buffer,int cnt)
        {
            await using var stream = new MemoryStream(buffer.Array, buffer.Offset, cnt);
            var byteArrayContent =new ByteArrayContent(stream.ToArray());
            return await byteArrayContent.ReadAsStreamAsync();
        }
      
    }
}