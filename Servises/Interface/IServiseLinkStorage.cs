
using System.Drawing;

namespace Servises.Interface;

public interface IServiseLinkStorage
{
    public Task<Uri> RegistrationNewUrlAsync(Uri url);
    public Task<byte[]> GenerateBarcodeForUrlAsync(Uri uri);
    public byte[] GenerateBarcodeForUrl(Uri uri);
}
