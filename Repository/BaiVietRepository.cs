using MangXaHoiWeb.Models;
using MangXaHoiWeb.ViewModels;

namespace MangXaHoiWeb.Repository
{
    public class BaiVietRepository : IBaiVietRepository
    {
        public QlmangXhContext db = new QlmangXhContext();
        public BaiVietNguoiDung Add(BaiVietNguoiDung baiVietNguoiDung)
        {
            throw new NotImplementedException();
        }

        public BaiVietNguoiDung Delete(string maBaiViet)
        {
            throw new NotImplementedException();
        }

        public List<BaiVietNguoiDung> GetAllBaiViet()
        {
            List<BaiViet> baiVietList = db.BaiViets.ToList();
            List<BaiVietNguoiDung> baiVietNguoiDungList = new List<BaiVietNguoiDung>();
            foreach (var baiViet in baiVietList)
            {
                NguoiDung nguoiDung = db.NguoiDungs.FirstOrDefault(nd => nd.MaNguoiDung == baiViet.MaNguoiDung);
                BaiVietNguoiDung baiVietNguoiDung = new BaiVietNguoiDung
                {
                    nguoiDung = nguoiDung,
                    baiViet = baiViet,
                    maNguoiDung = "phog"
                };
                baiVietNguoiDungList.Add(baiVietNguoiDung);
            }
            List<BaiVietNguoiDung> resultList = baiVietNguoiDungList.ToList();

            return resultList;
        }

        public List<BaiVietNguoiDung> GetBaiVietTheoNguoi(string maNguoiDung)
        {
            NguoiDung nguoiDung = db.NguoiDungs.FirstOrDefault(nd => nd.MaNguoiDung == maNguoiDung);

            if (nguoiDung == null)
            {
                throw new Exception("User not found.");
            }
            List<BaiViet> baiVietList = db.BaiViets.Where(bv => bv.MaNguoiDung == maNguoiDung).ToList();
            List<BaiVietNguoiDung> baiVietNguoiDungList = new List<BaiVietNguoiDung>();
            foreach (var baiViet in baiVietList)
            {
                BaiVietNguoiDung baiVietNguoiDung = new BaiVietNguoiDung
                {
                    nguoiDung = nguoiDung,
                    baiViet = baiViet,
                    maNguoiDung = maNguoiDung
                };
                baiVietNguoiDungList.Add(baiVietNguoiDung);
            }
            return baiVietNguoiDungList;
        }

        public BaiVietNguoiDung Update(BaiVietNguoiDung baiVietNguoiDung)
        {
            throw new NotImplementedException();
        }
    }
}
