using System.IO;

namespace OpenRGSS.Runtime.RGSS
{
    public class Table
    {
        public int xsize;
        public int ysize;
        public int zsize;
        private short[] data;

        public Table(int x, int y = 1, int z = 1)
        {
            this.xsize = x;
            this.ysize = y;
            this.zsize = z;

            this.data = new short[x * y * z];
        }

        public short this[int x, int y=0, int z=0]
        {
            get
            {
                x = x <= this.xsize ? x : this.xsize;
                y = y <= this.ysize ? y : this.ysize;
                z = z <= this.zsize ? z : this.zsize;

                return this.data[x + y * this.xsize + z * this.xsize * this.ysize];
            }

            set
            {
                x = x <= this.xsize ? x : this.xsize;
                y = y <= this.ysize ? y : this.ysize;
                z = z <= this.zsize ? z : this.zsize;

                this.data[x + y * this.xsize + z * this.xsize * this.ysize] = value;
            }
        }

        public static Table _load(byte[] data)
        {
            using(MemoryStream stream = new MemoryStream(data))
            {
                using(BinaryReader reader = new BinaryReader(stream))
                {
                    int size = reader.ReadInt32();
                    int x = reader.ReadInt32();
                    int y = reader.ReadInt32();
                    int z = reader.ReadInt32();
                    reader.ReadInt32();

                    Table table = new Table(x, y, z);
                    for (int i = 0; i < table.data.Length; i++)
                    {
                        table.data[i] = reader.ReadInt16();
                    }
                    return table;
                }
            }
        }

        public byte[] _dump(int d = 0)
        {
            /*
             *      s=[3].pack('L')
     s+=[@xsize].pack('L')+[@ysize].pack('L')+[@zsize].pack('L')
     s+=[@xsize*@ysize*@zsize].pack('L')
     for z in 0...@zsize
        for y in 0...@ysize
           for x in 0...@xsize
              s+=[@data[x+y*@xsize+z*@xsize*@ysize],0,0].pack('L')[0,2]
           end
        end
     end
     s
             */
            return null;
        }
    }
}
