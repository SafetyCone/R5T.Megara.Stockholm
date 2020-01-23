using System;

using R5T.Magyar.IO;
using R5T.Stockholm;


namespace R5T.Megara.Stockholm
{
    public class StreamFileSerializer<T> : IFileSerializer<T>
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
