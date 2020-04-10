using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DiDongTrongToi.Models.Login
{
    public static class SaveAcc
    {
        public static string TaiKhoanHienTai = "";

        public static void changeAccountHere(string Acc)
        {
            TaiKhoanHienTai = Acc;
        }
    }
}