using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLTHUVIEN.Utils
{
    public class LoadImageForDGV
    {
        public async void LoadImageAfterBinding(DataGridView dgv, string imageColumnName, string imagePathColumnName)
        {
            await Task.Delay(1000); 

            foreach (DataGridViewRow row in dgv.Rows)
            {
                if (row.Cells[imagePathColumnName].Value != null)
                {
                    string imagePath = Path.Combine(@"E:\DotNet\Image", row.Cells[imagePathColumnName].Value.ToString());

                    try
                    {
                        if (File.Exists(imagePath))
                        {
                            Image img = Image.FromFile(imagePath);
                            row.Cells[imageColumnName].Value = img;
                            Console.WriteLine("Đã tải hình ảnh từ: " + img);
                        }
                        else
                        {
                            Console.WriteLine("Không tìm thấy file: " + imagePath);
                            row.Cells[imageColumnName].Value = null;
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Lỗi khi tải hình ảnh: " + ex.Message);
                    }
                }
                else
                {
                    Console.WriteLine("Giá trị cell " + imagePathColumnName + " là null");
                }
            }
        }

    }
}
