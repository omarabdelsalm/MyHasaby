using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
namespace MyHasaby.Categories
{
    public class TafselCategory : ViewModelBase
    {
        private int id;
        private string name;
        private int quantity;
        private double soldout;
        private double residual;
        private double purchasprice;
        private double sellprice;
        private double netprofit;
        private int iDCategory;
        [PrimaryKey,AutoIncrement]
        public int ID
        {
            get { return id; }
            set
            {
                if (id != value)
                {
                    id = value;
                    OnPropertyChanged("ID");
                }
            }
        }
        [Indexed]
        public int IDCategory {
            get { return iDCategory; }
            set {
                if (iDCategory != value)
                {
                    iDCategory = value;
                    OnPropertyChanged("IDCategory");
                }

            } }
        public string Name
        {
            get { return name; }
            set {
                  if (name != value) 
                        {
                          name = value;
                          OnPropertyChanged("ID");
                        }
                 }
        }
        //الكمية
        public int Quantity { 
            get { return quantity; }
            set {
                if (quantity != value)
                {
                    quantity = value;
                    OnPropertyChanged("Quantity");
                }

            } }
        //ما تم بيعه
        public double Soldout {
            get { return soldout; }
            set {
                if (soldout!=value)
                {
                    soldout = value;
                    OnPropertyChanged("Soldout");

                }
            } }
        //المتبقى
        public double Residual
        {
            get { return residual; }
            set
            {
                if (residual != value)
                {
                    residual = value;
                    OnPropertyChanged("Residual");
                }
            }
        }
        //سعر الشراء
        public double Purchasprice {
            get { return purchasprice; }
            set {
                if (purchasprice != value)
                {
                    purchasprice = value;
                    OnPropertyChanged("Purchasprice");
                }
            } }
        //سعر البيع
        public double Sellprice {
            get { return sellprice; }
            set {
                if (sellprice != value)
                {
                    sellprice = value;
                    OnPropertyChanged("Sellprice");
                }
            } 
        }
        //صافي الربح
        public double Netprofit {
            get { return netprofit; }
            set {
                if (netprofit != value)
                {
                    netprofit = value;
                    OnPropertyChanged("Netprofit");
                }
            } }
    }
}
