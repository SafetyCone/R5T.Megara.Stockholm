using System;
using System.IO;

using R5T.Stockholm;

using R5T.T0064;


namespace R5T.Megara.Stockholm
{
    [ServiceImplementationMarker]
    public class StreamFileSerializer<T> : IFileSerializer<T>, IServiceImplementation
    {
        private IStreamSerializer<T> StreamSerializer { get; }


        public StreamFileSerializer(IStreamSerializer<T> streamSerializer)
        {
            this.StreamSerializer = streamSerializer;
        }

        public T Deserialize(string filePath)
        {
            using (var fileStream = FileStreamHelper.NewRead(filePath))
            {
                var value = this.StreamSerializer.Deserialize(fileStream);
                return value;
            }
        }

        public void Serialize(string filePath, T value, bool overwrite = true)
        {
            using (var fileStream = FileStreamHelper.NewWrite(filePath, overwrite))
            {
                this.StreamSerializer.Serialize(fileStream, value);
            }
        }
    }
}
