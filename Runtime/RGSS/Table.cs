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

        /*
         * 
  def [](x, y = 0, z = 0)
     x = [x, @xsize].min
     y = [y, @ysize].min
     z = [z, @zsize].min
     @data[x + y * @xsize + z * @xsize * @ysize]
  end
  def []=(*args)
     x = [args[0], @xsize].min
     y = [args.size>2 ?args[1] : 0, @ysize].min
     z = [args.size>3 ?args[2] : 0, @zsize].min
     v = [args.pop, 256 ** 4].min
     @data[x + y * @xsize + z * @xsize * @ysize] = v
  end
         */

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
