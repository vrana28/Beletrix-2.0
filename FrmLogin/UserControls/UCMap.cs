using Controller;
using Domain;
using FrmLogin.Controllers;
using FrmLogin.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrmLogin.UserControls
{
    public partial class UCMap : UserControl
    {
        public List<RadioButton> RButtons { get; set; } = new List<RadioButton>();
        private readonly MapController mapController;
        public UCMap(Controllers.MapController mapController)
        {
            this.mapController = mapController;
            InitializeComponent();
            RButtons.Add(rb1);
            RButtons.Add(rb2);
            RButtons.Add(rb3);
            RButtons.Add(rb4);
            RButtons.Add(rb5);
        }

        public DataGridView DGVStanjeNaPoziciji{ get=>dgvStanjeNaPoziciji; }

        private void btnUlaz_Click(object sender, EventArgs e)
        {
            mapController.OpenFrmEntrance(this);
        }

        private void btnPovezi_Click(object sender, EventArgs e)
        {
            mapController.OpenFrmPositioning(this);
        }

        public void ShowPosition(string pozicija) {

            mapController.ShowPositin(this,pozicija);
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            mapController.Find(this);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            mapController.LeavingItems(this);
        }

        #region Buttons
        private void A01_Click(object sender, EventArgs e)
        {
            ShowPosition(A01.Name);
        }

        private void A02_Click(object sender, EventArgs e)
        {
            ShowPosition(A02.Name);
        }

        private void A03_Click(object sender, EventArgs e)
        {
            ShowPosition(A03.Name);
        }
        private void A04_Click(object sender, EventArgs e)
        {
            ShowPosition(A04.Name);
        }

        private void A11_Click(object sender, EventArgs e)
        {
            ShowPosition(A11.Name);
        }

        private void A12_Click(object sender, EventArgs e)
        {
            ShowPosition(A12.Name);
        }

        private void A13_Click(object sender, EventArgs e)
        {
            ShowPosition(A13.Name);
        }

        private void A14_Click(object sender, EventArgs e)
        {
            ShowPosition(A14.Name);
        }

        private void A21_Click(object sender, EventArgs e)
        {
            ShowPosition(A21.Name);
        }

        private void A22_Click(object sender, EventArgs e)
        {
            ShowPosition(A22.Name);
        }

        private void A23_Click(object sender, EventArgs e)
        {
            ShowPosition(A23.Name);
        }

        private void A24_Click(object sender, EventArgs e)
        {
            ShowPosition(A24.Name);
        }

        private void A31_Click(object sender, EventArgs e)
        {
            ShowPosition(A31.Name);
        }

        private void A32_Click(object sender, EventArgs e)
        {
            ShowPosition(A32.Name);
        }

        private void A33_Click(object sender, EventArgs e)
        {
            ShowPosition(A33.Name);
        }

        private void A34_Click(object sender, EventArgs e)
        {
            ShowPosition(A34.Name);
        }

        private void A41_Click(object sender, EventArgs e)
        {
            ShowPosition(A41.Name);
        }

        private void A42_Click(object sender, EventArgs e)
        {
            ShowPosition(A42.Name);
        }

        private void A43_Click(object sender, EventArgs e)
        {
            ShowPosition(A43.Name);
        }

        private void A44_Click(object sender, EventArgs e)
        {
            ShowPosition(A44.Name);
        }

        private void A51_Click(object sender, EventArgs e)
        {
            ShowPosition(A51.Name);
        }

        private void A52_Click(object sender, EventArgs e)
        {
            ShowPosition(A52.Name);
        }

        private void A53_Click(object sender, EventArgs e)
        {
            ShowPosition(A53.Name);
        }

        private void A54_Click(object sender, EventArgs e)
        {
            ShowPosition(A54.Name);
        }

        private void A61_Click(object sender, EventArgs e)
        {
            ShowPosition(A61.Name);
        }

        private void A62_Click(object sender, EventArgs e)
        {
            ShowPosition(A62.Name);
        }

        private void A63_Click(object sender, EventArgs e)
        {
            ShowPosition(A63.Name);
        }

        private void A64_Click(object sender, EventArgs e)
        {
            ShowPosition(A64.Name);
        }

        private void A71_Click(object sender, EventArgs e)
        {
            ShowPosition(A71.Name);
        }

        private void A72_Click(object sender, EventArgs e)
        {
            ShowPosition(A72.Name);
        }

        private void A73_Click(object sender, EventArgs e)
        {
            ShowPosition(A73.Name);
        }

        private void A74_Click(object sender, EventArgs e)
        {
            ShowPosition(A74.Name);
        }

        private void B11_Click(object sender, EventArgs e)
        {
            ShowPosition(B11.Name);
        }

        private void B12_Click(object sender, EventArgs e)
        {
            ShowPosition(B12.Name);
        }

        private void B13_Click(object sender, EventArgs e)
        {
            ShowPosition(B13.Name);
        }

        private void B14_Click(object sender, EventArgs e)
        {
            ShowPosition(B14.Name);
        }

        private void B21_Click(object sender, EventArgs e)
        {
            ShowPosition(B21.Name);
        }

        private void B22_Click(object sender, EventArgs e)
        {
            ShowPosition(B22.Name);
        }

        private void B23_Click(object sender, EventArgs e)
        {
            ShowPosition(B23.Name);
        }

        private void B24_Click(object sender, EventArgs e)
        {
            ShowPosition(B24.Name);
        }

        private void B31_Click(object sender, EventArgs e)
        {
            ShowPosition(B31.Name);
        }

        private void B32_Click(object sender, EventArgs e)
        {
            ShowPosition(B32.Name);
        }

        private void B33_Click(object sender, EventArgs e)
        {
            ShowPosition(B33.Name);
        }

        private void B34_Click(object sender, EventArgs e)
        {
            ShowPosition(B34.Name);
        }

        private void B41_Click(object sender, EventArgs e)
        {
            ShowPosition(B41.Name);
        }

        private void B42_Click(object sender, EventArgs e)
        {
            ShowPosition(B42.Name);
        }

        private void B43_Click(object sender, EventArgs e)
        {
            ShowPosition(B43.Name);
        }

        private void B44_Click(object sender, EventArgs e)
        {
            ShowPosition(B44.Name);
        }

        private void B51_Click(object sender, EventArgs e)
        {
            ShowPosition(B51.Name);
        }

        private void B52_Click(object sender, EventArgs e)
        {
            ShowPosition(B52.Name);
        }

        private void B53_Click(object sender, EventArgs e)
        {
            ShowPosition(B53.Name);
        }

        private void B54_Click(object sender, EventArgs e)
        {
            ShowPosition(B54.Name);
        }

        private void B61_Click(object sender, EventArgs e)
        {
            ShowPosition(B61.Name);
        }

        private void B62_Click(object sender, EventArgs e)
        {
            ShowPosition(B62.Name);
        }

        private void B63_Click(object sender, EventArgs e)
        {
            ShowPosition(B63.Name);
        }

        private void B64_Click(object sender, EventArgs e)
        {
            ShowPosition(B64.Name);
        }

        private void B71_Click(object sender, EventArgs e)
        {
            ShowPosition(B71.Name);
        }

        private void B72_Click(object sender, EventArgs e)
        {
            ShowPosition(B72.Name);
        }

        private void B73_Click(object sender, EventArgs e)
        {
            ShowPosition(B73.Name);
        }

        private void B74_Click(object sender, EventArgs e)
        {
            ShowPosition(B74.Name);
        }

       

        private void C11_Click(object sender, EventArgs e)
        {
            ShowPosition(C11.Name);
        }

        private void C12_Click(object sender, EventArgs e)
        {
            ShowPosition(C12.Name);
        }

        private void C13_Click(object sender, EventArgs e)
        {
            ShowPosition(C13.Name);
        }

        private void C14_Click(object sender, EventArgs e)
        {
            ShowPosition(C14.Name);
        }

        private void C21_Click(object sender, EventArgs e)
        {
            ShowPosition(C21.Name);
        }

        private void C22_Click(object sender, EventArgs e)
        {
            ShowPosition(C22.Name);
        }

        private void C23_Click(object sender, EventArgs e)
        {
            ShowPosition(C23.Name);
        }

        private void C24_Click(object sender, EventArgs e)
        {
            ShowPosition(C24.Name);
        }

        private void C31_Click(object sender, EventArgs e)
        {
            ShowPosition(C31.Name);
        }

        private void C32_Click(object sender, EventArgs e)
        {
            ShowPosition(C32.Name);
        }

        private void C33_Click(object sender, EventArgs e)
        {
            ShowPosition(C33.Name);
        }

        private void C34_Click(object sender, EventArgs e)
        {
            ShowPosition(C34.Name);
        }

        private void C41_Click(object sender, EventArgs e)
        {
            ShowPosition(C41.Name);
        }

        private void C42_Click(object sender, EventArgs e)
        {
            ShowPosition(C42.Name);
        }

        private void C43_Click(object sender, EventArgs e)
        {
            ShowPosition(C43.Name);
        }

        private void C44_Click(object sender, EventArgs e)
        {
            ShowPosition(C44.Name);
        }

        private void C51_Click(object sender, EventArgs e)
        {
            ShowPosition(C51.Name);
        }

        private void C52_Click(object sender, EventArgs e)
        {
            ShowPosition(C52.Name);
        }

        private void C53_Click(object sender, EventArgs e)
        {
            ShowPosition(C53.Name);
        }

        private void C54_Click(object sender, EventArgs e)
        {
            ShowPosition(C54.Name);
        }

        private void C61_Click(object sender, EventArgs e)
        {
            ShowPosition(C61.Name);
        }

        private void C62_Click(object sender, EventArgs e)
        {
            ShowPosition(C62.Name);
        }

        private void C63_Click(object sender, EventArgs e)
        {
            ShowPosition(C63.Name);
        }

        private void C64_Click(object sender, EventArgs e)
        {
            ShowPosition(C64.Name);
        }

        private void C71_Click(object sender, EventArgs e)
        {
            ShowPosition(C71.Name);
        }

        private void C72_Click(object sender, EventArgs e)
        {
            ShowPosition(C72.Name);
        }

        private void C73_Click(object sender, EventArgs e)
        {
            ShowPosition(C73.Name);
        }

        private void C74_Click(object sender, EventArgs e)
        {
            ShowPosition(C74.Name);
        }

        private void D11_Click(object sender, EventArgs e)
        {
            ShowPosition(D11.Name);
        }

        private void D12_Click(object sender, EventArgs e)
        {
            ShowPosition(D12.Name);
        }

        private void D13_Click(object sender, EventArgs e)
        {
            ShowPosition(D13.Name);
        }

        private void D14_Click(object sender, EventArgs e)
        {
            ShowPosition(D14.Name);
        }

        private void D21_Click(object sender, EventArgs e)
        {
            ShowPosition(D21.Name);
        }

        private void D22_Click(object sender, EventArgs e)
        {
            ShowPosition(D22.Name);
        }

        private void D23_Click(object sender, EventArgs e)
        {
            ShowPosition(D23.Name);
        }

        private void D24_Click(object sender, EventArgs e)
        {
            ShowPosition(D24.Name);
        }

        private void D31_Click(object sender, EventArgs e)
        {
            ShowPosition(D31.Name);
        }

        private void D32_Click(object sender, EventArgs e)
        {
            ShowPosition(D32.Name);
        }

        private void D33_Click(object sender, EventArgs e)
        {
            ShowPosition(D33.Name);
        }

        private void D34_Click(object sender, EventArgs e)
        {
            ShowPosition(D34.Name);
        }

        private void D41_Click(object sender, EventArgs e)
        {
            ShowPosition(D41.Name);
        }

        private void D42_Click(object sender, EventArgs e)
        {
            ShowPosition(D42.Name);
        }

        private void D43_Click(object sender, EventArgs e)
        {
            ShowPosition(D43.Name);
        }

        private void D44_Click(object sender, EventArgs e)
        {
            ShowPosition(D44.Name);
        }

        private void D51_Click(object sender, EventArgs e)
        {
            ShowPosition(D51.Name);
        }

        private void D52_Click(object sender, EventArgs e)
        {
            ShowPosition(D52.Name);
        }

        private void D53_Click(object sender, EventArgs e)
        {
            ShowPosition(D53.Name);
        }

        private void D54_Click(object sender, EventArgs e)
        {
            ShowPosition(D54.Name);
        }

        private void D61_Click(object sender, EventArgs e)
        {
            ShowPosition(D61.Name);
        }

        private void D62_Click(object sender, EventArgs e)
        {
            ShowPosition(D62.Name);
        }

        private void D63_Click(object sender, EventArgs e)
        {
            ShowPosition(D63.Name);
        }

        private void D64_Click(object sender, EventArgs e)
        {
            ShowPosition(D64.Name);
        }

        private void D71_Click(object sender, EventArgs e)
        {
            ShowPosition(D71.Name);
        }

        private void D72_Click(object sender, EventArgs e)
        {
            ShowPosition(D72.Name);
        }

        private void D73_Click(object sender, EventArgs e)
        {
            ShowPosition(D73.Name);
        }

        private void D74_Click(object sender, EventArgs e)
        {
            ShowPosition(D74.Name);
        }

        private void E11_Click(object sender, EventArgs e)
        {
            ShowPosition(E11.Name);
        }

        private void E12_Click(object sender, EventArgs e)
        {
            ShowPosition(E12.Name);
        }

        private void E13_Click(object sender, EventArgs e)
        {
            ShowPosition(E13.Name);
        }

        private void E14_Click(object sender, EventArgs e)
        {
            ShowPosition(E14.Name);
        }

        private void E21_Click(object sender, EventArgs e)
        {
            ShowPosition(E21.Name);
        }

        private void E22_Click(object sender, EventArgs e)
        {
            ShowPosition(E22.Name);
        }

        private void E23_Click(object sender, EventArgs e)
        {
            ShowPosition(E23.Name);
        }

        private void E24_Click(object sender, EventArgs e)
        {
            ShowPosition(E24.Name);
        }

        private void E31_Click(object sender, EventArgs e)
        {
            ShowPosition(E31.Name);
        }

        private void E32_Click(object sender, EventArgs e)
        {
            ShowPosition(E32.Name);
        }

        private void E33_Click(object sender, EventArgs e)
        {
            ShowPosition(E33.Name);
        }

        private void E34_Click(object sender, EventArgs e)
        {
            ShowPosition(E34.Name);
        }

        private void E41_Click(object sender, EventArgs e)
        {
            ShowPosition(E41.Name);
        }

        private void E42_Click(object sender, EventArgs e)
        {
            ShowPosition(E42.Name);
        }

        private void E43_Click(object sender, EventArgs e)
        {
            ShowPosition(E43.Name);
        }

        private void E44_Click(object sender, EventArgs e)
        {
            ShowPosition(E44.Name);
        }

        private void E51_Click(object sender, EventArgs e)
        {
            ShowPosition(E51.Name);
        }

        private void E52_Click(object sender, EventArgs e)
        {
            ShowPosition(E52.Name);
        }

        private void E53_Click(object sender, EventArgs e)
        {
            ShowPosition(E53.Name);
        }

        private void E54_Click(object sender, EventArgs e)
        {
            ShowPosition(E54.Name);
        }

        private void E61_Click(object sender, EventArgs e)
        {
            ShowPosition(E61.Name);
        }

        private void E62_Click(object sender, EventArgs e)
        {
            ShowPosition(E62.Name);
        }

        private void E63_Click(object sender, EventArgs e)
        {
            ShowPosition(E63.Name);
        }

        private void E64_Click(object sender, EventArgs e)
        {
            ShowPosition(E64.Name);
        }

        private void E71_Click(object sender, EventArgs e)
        {
            ShowPosition(E71.Name);
        }

        private void E72_Click(object sender, EventArgs e)
        {
            ShowPosition(E72.Name);
        }

        private void E73_Click(object sender, EventArgs e)
        {
            ShowPosition(E73.Name);
        }

        private void E74_Click(object sender, EventArgs e)
        {
            ShowPosition(E74.Name);
        }

        private void F11_Click(object sender, EventArgs e)
        {
            ShowPosition(F11.Name);
        }

        private void F12_Click(object sender, EventArgs e)
        {
            ShowPosition(F12.Name);
        }

        private void F13_Click(object sender, EventArgs e)
        {
            ShowPosition(F13.Name);
        }

        private void F14_Click(object sender, EventArgs e)
        {
            ShowPosition(F14.Name);
        }

        private void F21_Click(object sender, EventArgs e)
        {
            ShowPosition(F21.Name);
        }

        private void F22_Click(object sender, EventArgs e)
        {
            ShowPosition(F22.Name);
        }

        private void F23_Click(object sender, EventArgs e)
        {
            ShowPosition(F23.Name);
        }

        private void F24_Click(object sender, EventArgs e)
        {
            ShowPosition(F24.Name);
        }

        private void F31_Click(object sender, EventArgs e)
        {
            ShowPosition(F31.Name);
        }

        private void F32_Click(object sender, EventArgs e)
        {
            ShowPosition(F32.Name);
        }

        private void F33_Click(object sender, EventArgs e)
        {
            ShowPosition(F33.Name);
        }

        private void F34_Click(object sender, EventArgs e)
        {
            ShowPosition(F34.Name);
        }

        private void F41_Click(object sender, EventArgs e)
        {
            ShowPosition(F41.Name);
        }

        private void F42_Click(object sender, EventArgs e)
        {
            ShowPosition(F42.Name);
        }

        private void F43_Click(object sender, EventArgs e)
        {
            ShowPosition(F43.Name);
        }

        private void F44_Click(object sender, EventArgs e)
        {
            ShowPosition(F44.Name);
        }

        private void F51_Click(object sender, EventArgs e)
        {
            ShowPosition(F51.Name);
        }

        private void F52_Click(object sender, EventArgs e)
        {
            ShowPosition(F52.Name);
        }

        private void F53_Click(object sender, EventArgs e)
        {
            ShowPosition(F53.Name);
        }

        private void F54_Click(object sender, EventArgs e)
        {
            ShowPosition(F54.Name);
        }

        private void F61_Click(object sender, EventArgs e)
        {
            ShowPosition(F61.Name);
        }

        private void F62_Click(object sender, EventArgs e)
        {
            ShowPosition(F62.Name);
        }

        private void F63_Click(object sender, EventArgs e)
        {
            ShowPosition(F63.Name);
        }

        private void F64_Click(object sender, EventArgs e)
        {
            ShowPosition(F64.Name);
        }

        private void F71_Click(object sender, EventArgs e)
        {
            ShowPosition(F71.Name);
        }

        private void F72_Click(object sender, EventArgs e)
        {
            ShowPosition(F72.Name);
        }

        private void F73_Click(object sender, EventArgs e)
        {
            ShowPosition(F73.Name);
        }

        private void F74_Click(object sender, EventArgs e)
        {
            ShowPosition(F74.Name);
        }

        private void G11_Click(object sender, EventArgs e)
        {
            ShowPosition(G11.Name);
        }

        private void G12_Click(object sender, EventArgs e)
        {
            ShowPosition(G12.Name);
        }

        private void G13_Click(object sender, EventArgs e)
        {
            ShowPosition(G13.Name);
        }

        private void G14_Click(object sender, EventArgs e)
        {
            ShowPosition(G14.Name);
        }

        private void G21_Click(object sender, EventArgs e)
        {
            ShowPosition(G21.Name);
        }

        private void G22_Click(object sender, EventArgs e)
        {
            ShowPosition(G22.Name);
        }

        private void G23_Click(object sender, EventArgs e)
        {
            ShowPosition(G23.Name);
        }

        private void G24_Click(object sender, EventArgs e)
        {
            ShowPosition(G24.Name);
        }

        private void G31_Click(object sender, EventArgs e)
        {
            ShowPosition(G31.Name);
        }

        private void G32_Click(object sender, EventArgs e)
        {
            ShowPosition(G32.Name);
        }

        private void G33_Click(object sender, EventArgs e)
        {
            ShowPosition(G33.Name);
        }

        private void G34_Click(object sender, EventArgs e)
        {
            ShowPosition(G34.Name);
        }

        private void G41_Click(object sender, EventArgs e)
        {
            ShowPosition(G41.Name);
        }

        private void G42_Click(object sender, EventArgs e)
        {
            ShowPosition(G42.Name);
        }

        private void G43_Click(object sender, EventArgs e)
        {
            ShowPosition(G43.Name);
        }

        private void G44_Click(object sender, EventArgs e)
        {
            ShowPosition(G44.Name);
        }

        private void G51_Click(object sender, EventArgs e)
        {
            ShowPosition(G51.Name);
        }

        private void G52_Click(object sender, EventArgs e)
        {
            ShowPosition(G52.Name);
        }

        private void G53_Click(object sender, EventArgs e)
        {
            ShowPosition(G53.Name);
        }

        private void G54_Click(object sender, EventArgs e)
        {
            ShowPosition(G54.Name);
        }

        private void G61_Click(object sender, EventArgs e)
        {
            ShowPosition(G61.Name);
        }

        private void G62_Click(object sender, EventArgs e)
        {
            ShowPosition(G62.Name);
        }

        private void G63_Click(object sender, EventArgs e)
        {
            ShowPosition(G63.Name);
        }

        private void G64_Click(object sender, EventArgs e)
        {
            ShowPosition(G64.Name);
        }

        private void G71_Click(object sender, EventArgs e)
        {
            ShowPosition(G71.Name);
        }

        private void G72_Click(object sender, EventArgs e)
        {
            ShowPosition(G72.Name);
        }

        private void G73_Click(object sender, EventArgs e)
        {
            ShowPosition(G73.Name);
        }

        private void G74_Click(object sender, EventArgs e)
        {
            ShowPosition(G74.Name);
        }

        private void H11_Click(object sender, EventArgs e)
        {
            ShowPosition(H11.Name);
        }

        private void H12_Click(object sender, EventArgs e)
        {
            ShowPosition(H12.Name);
        }

        private void H13_Click(object sender, EventArgs e)
        {
            ShowPosition(H13.Name);
        }

        private void H14_Click(object sender, EventArgs e)
        {
            ShowPosition(H14.Name);
        }

        private void H21_Click(object sender, EventArgs e)
        {
            ShowPosition(H21.Name);
        }

        private void H22_Click(object sender, EventArgs e)
        {
            ShowPosition(H22.Name);
        }

        private void H23_Click(object sender, EventArgs e)
        {
            ShowPosition(H23.Name);
        }

        private void H24_Click(object sender, EventArgs e)
        {
            ShowPosition(H24.Name);
        }

        private void H31_Click(object sender, EventArgs e)
        {
            ShowPosition(H31.Name);
        }

        private void H32_Click(object sender, EventArgs e)
        {
            ShowPosition(H32.Name);
        }

        private void H33_Click(object sender, EventArgs e)
        {
            ShowPosition(H33.Name);
        }

        private void H34_Click(object sender, EventArgs e)
        {
            ShowPosition(H34.Name);
        }

        private void H41_Click(object sender, EventArgs e)
        {
            ShowPosition(H41.Name);
        }

        private void H42_Click(object sender, EventArgs e)
        {
            ShowPosition(H42.Name);
        }

        private void H43_Click(object sender, EventArgs e)
        {
            ShowPosition(H43.Name);
        }

        private void H44_Click(object sender, EventArgs e)
        {
            ShowPosition(H44.Name);
        }

        private void H51_Click(object sender, EventArgs e)
        {
            ShowPosition(H51.Name);
        }

        private void H52_Click(object sender, EventArgs e)
        {
            ShowPosition(H52.Name);
        }

        private void H53_Click(object sender, EventArgs e)
        {
            ShowPosition(H53.Name);
        }

        private void H54_Click(object sender, EventArgs e)
        {
            ShowPosition(H54.Name);
        }

        private void H61_Click(object sender, EventArgs e)
        {
            ShowPosition(H61.Name);
        }

        private void H62_Click(object sender, EventArgs e)
        {
            ShowPosition(H62.Name);
        }

        private void H63_Click(object sender, EventArgs e)
        {
            ShowPosition(H63.Name);
        }

        private void H64_Click(object sender, EventArgs e)
        {
            ShowPosition(H64.Name);
        }

        private void H71_Click(object sender, EventArgs e)
        {
            ShowPosition(H71.Name);
        }

        private void H72_Click(object sender, EventArgs e)
        {
            ShowPosition(H72.Name);
        }

        private void H73_Click(object sender, EventArgs e)
        {
            ShowPosition(H73.Name);
        }

        private void H74_Click(object sender, EventArgs e)
        {
            ShowPosition(H74.Name);
        }

        private void I11_Click(object sender, EventArgs e)
        {
            ShowPosition(I11.Name);
        }

        private void I12_Click(object sender, EventArgs e)
        {
            ShowPosition(I12.Name);
        }

        private void I13_Click(object sender, EventArgs e)
        {
            ShowPosition(I13.Name);
        }

        private void I14_Click(object sender, EventArgs e)
        {
            ShowPosition(I14.Name);
        }

        private void I21_Click(object sender, EventArgs e)
        {
            ShowPosition(I21.Name);
        }

        private void I22_Click(object sender, EventArgs e)
        {
            ShowPosition(I22.Name);
        }

        private void I23_Click(object sender, EventArgs e)
        {
            ShowPosition(I23.Name);
        }

        private void I24_Click(object sender, EventArgs e)
        {
            ShowPosition(I24.Name);
        }

        private void I31_Click(object sender, EventArgs e)
        {
            ShowPosition(I31.Name);
        }

        private void I32_Click(object sender, EventArgs e)
        {
            ShowPosition(I32.Name);
        }

        private void I33_Click(object sender, EventArgs e)
        {
            ShowPosition(I33.Name);
        }

        private void I34_Click(object sender, EventArgs e)
        {
            ShowPosition(I34.Name);
        }

        private void I41_Click(object sender, EventArgs e)
        {
            ShowPosition(I41.Name);
        }

        private void I42_Click(object sender, EventArgs e)
        {
            ShowPosition(I42.Name);
        }

        private void I43_Click(object sender, EventArgs e)
        {
            ShowPosition(I43.Name);
        }

        private void I44_Click(object sender, EventArgs e)
        {
            ShowPosition(I44.Name);
        }

        private void I51_Click(object sender, EventArgs e)
        {
            ShowPosition(I51.Name);
        }

        private void I52_Click(object sender, EventArgs e)
        {
            ShowPosition(I52.Name);
        }

        private void I53_Click(object sender, EventArgs e)
        {
            ShowPosition(I53.Name);
        }

        private void I54_Click(object sender, EventArgs e)
        {
            ShowPosition(I54.Name);
        }

        private void I61_Click(object sender, EventArgs e)
        {
            ShowPosition(I61.Name);
        }

        private void I62_Click(object sender, EventArgs e)
        {
            ShowPosition(I62.Name);
        }

        private void I63_Click(object sender, EventArgs e)
        {
            ShowPosition(I63.Name);
        }

        private void I64_Click(object sender, EventArgs e)
        {
            ShowPosition(I64.Name);
        }

        private void I71_Click(object sender, EventArgs e)
        {
            ShowPosition(I71.Name);
        }

        private void I72_Click(object sender, EventArgs e)
        {
            ShowPosition(I72.Name);
        }

        private void I73_Click(object sender, EventArgs e)
        {
            ShowPosition(I73.Name);
        }

        private void I74_Click(object sender, EventArgs e)
        {
            ShowPosition(I74.Name);
        }

        private void J11_Click(object sender, EventArgs e)
        {
            ShowPosition(J11.Name);
        }

        private void J12_Click(object sender, EventArgs e)
        {
            ShowPosition(J12.Name);
        }

        private void J13_Click(object sender, EventArgs e)
        {
            ShowPosition(J13.Name);
        }

        private void J14_Click(object sender, EventArgs e)
        {
            ShowPosition(J14.Name);
        }

        private void J21_Click(object sender, EventArgs e)
        {
            ShowPosition(J21.Name);
        }

        private void J22_Click(object sender, EventArgs e)
        {
            ShowPosition(J22.Name);
        }

        private void J23_Click(object sender, EventArgs e)
        {
            ShowPosition(J23.Name);
        }

        private void J24_Click(object sender, EventArgs e)
        {
            ShowPosition(J24.Name);
        }

        private void J31_Click(object sender, EventArgs e)
        {
            ShowPosition(J31.Name);
        }

        private void J32_Click(object sender, EventArgs e)
        {
            ShowPosition(J32.Name);
        }

        private void J33_Click(object sender, EventArgs e)
        {
            ShowPosition(J33.Name);
        }

        private void J34_Click(object sender, EventArgs e)
        {
            ShowPosition(J34.Name);
        }

        private void J41_Click(object sender, EventArgs e)
        {
            ShowPosition(J41.Name);
        }

        private void J42_Click(object sender, EventArgs e)
        {
            ShowPosition(J42.Name);
        }

        private void J43_Click(object sender, EventArgs e)
        {
            ShowPosition(J43.Name);
        }

        private void J44_Click(object sender, EventArgs e)
        {
            ShowPosition(J44.Name);
        }

        private void J51_Click(object sender, EventArgs e)
        {
            ShowPosition(J51.Name);
        }

        private void J52_Click(object sender, EventArgs e)
        {
            ShowPosition(J52.Name);
        }

        private void J53_Click(object sender, EventArgs e)
        {
            ShowPosition(J53.Name);
        }

        private void J54_Click(object sender, EventArgs e)
        {
            ShowPosition(J54.Name);
        }

        private void J61_Click(object sender, EventArgs e)
        {
            ShowPosition(J61.Name);
        }

        private void J62_Click(object sender, EventArgs e)
        {
            ShowPosition(J62.Name);
        }

        private void J63_Click(object sender, EventArgs e)
        {
            ShowPosition(J63.Name);
        }

        private void J64_Click(object sender, EventArgs e)
        {
            ShowPosition(J64.Name);
        }

        private void J71_Click(object sender, EventArgs e)
        {
            ShowPosition(J71.Name);
        }

        private void J72_Click(object sender, EventArgs e)
        {
            ShowPosition(J72.Name);
        }

        private void J73_Click(object sender, EventArgs e)
        {
            ShowPosition(J73.Name);
        }

        private void J74_Click(object sender, EventArgs e)
        {
            ShowPosition(J74.Name);
        }

        private void K11_Click(object sender, EventArgs e)
        {
            ShowPosition(K11.Name);
        }

        private void K12_Click(object sender, EventArgs e)
        {
            ShowPosition(K12.Name);
        }

        private void K13_Click(object sender, EventArgs e)
        {
            ShowPosition(K13.Name);
        }

        private void K14_Click(object sender, EventArgs e)
        {
            ShowPosition(K14.Name);
        }

        private void K21_Click(object sender, EventArgs e)
        {
            ShowPosition(K21.Name);
        }

        private void K22_Click(object sender, EventArgs e)
        {
            ShowPosition(K22.Name);
        }

        private void K23_Click(object sender, EventArgs e)
        {
            ShowPosition(K23.Name);
        }

        private void K24_Click(object sender, EventArgs e)
        {
            ShowPosition(K24.Name);
        }

        private void K31_Click(object sender, EventArgs e)
        {
            ShowPosition(K31.Name);
        }

        private void K32_Click(object sender, EventArgs e)
        {
            ShowPosition(K32.Name);
        }

        private void K33_Click(object sender, EventArgs e)
        {
            ShowPosition(K33.Name);
        }

        private void K34_Click(object sender, EventArgs e)
        {
            ShowPosition(K34.Name);
        }

        private void K41_Click(object sender, EventArgs e)
        {
            ShowPosition(K41.Name);
        }

        private void K42_Click(object sender, EventArgs e)
        {
            ShowPosition(K42.Name);
        }

        private void K43_Click(object sender, EventArgs e)
        {
            ShowPosition(K43.Name);
        }

        private void K44_Click(object sender, EventArgs e)
        {
            ShowPosition(K44.Name);
        }

        private void K51_Click(object sender, EventArgs e)
        {
            ShowPosition(K51.Name);
        }

        private void K52_Click(object sender, EventArgs e)
        {
            ShowPosition(K52.Name);
        }

        private void K53_Click(object sender, EventArgs e)
        {
            ShowPosition(K53.Name);
        }

        private void K54_Click(object sender, EventArgs e)
        {
            ShowPosition(K54.Name);
        }

        private void K61_Click(object sender, EventArgs e)
        {
            ShowPosition(K61.Name);
        }

        private void K62_Click(object sender, EventArgs e)
        {
            ShowPosition(K62.Name);
        }

        private void K63_Click(object sender, EventArgs e)
        {
            ShowPosition(K63.Name);
        }

        private void K64_Click(object sender, EventArgs e)
        {
            ShowPosition(K64.Name);
        }

        private void K71_Click(object sender, EventArgs e)
        {
            ShowPosition(K71.Name);
        }

        private void K72_Click(object sender, EventArgs e)
        {
            ShowPosition(K72.Name);
        }

        private void K73_Click(object sender, EventArgs e)
        {
            ShowPosition(K73.Name);
        }

        private void K74_Click(object sender, EventArgs e)
        {
            ShowPosition(K74.Name);
        }

        private void L11_Click(object sender, EventArgs e)
        {
            ShowPosition(L11.Name);
        }

        private void L12_Click(object sender, EventArgs e)
        {
            ShowPosition(L12.Name);
        }

        private void L13_Click(object sender, EventArgs e)
        {
            ShowPosition(L13.Name);
        }

        private void L14_Click(object sender, EventArgs e)
        {
            ShowPosition(L14.Name);
        }

        private void L21_Click(object sender, EventArgs e)
        {
            ShowPosition(L21.Name);
        }

        private void L22_Click(object sender, EventArgs e)
        {
            ShowPosition(L22.Name);
        }

        private void L23_Click(object sender, EventArgs e)
        {
            ShowPosition(L23.Name);
        }

        private void L24_Click(object sender, EventArgs e)
        {
            ShowPosition(L24.Name);
        }

        private void L31_Click(object sender, EventArgs e)
        {
            ShowPosition(L31.Name);
        }

        private void L32_Click(object sender, EventArgs e)
        {
            ShowPosition(L32.Name);
        }

        private void L33_Click(object sender, EventArgs e)
        {
            ShowPosition(L33.Name);
        }

        private void L34_Click(object sender, EventArgs e)
        {
            ShowPosition(L34.Name);
        }

        private void L41_Click(object sender, EventArgs e)
        {
            ShowPosition(L41.Name);
        }

        private void L42_Click(object sender, EventArgs e)
        {
            ShowPosition(L42.Name);
        }

        private void L43_Click(object sender, EventArgs e)
        {
            ShowPosition(L43.Name);
        }

        private void L44_Click(object sender, EventArgs e)
        {
            ShowPosition(L44.Name);
        }

        private void L51_Click(object sender, EventArgs e)
        {
            ShowPosition(L51.Name);
        }

        private void L52_Click(object sender, EventArgs e)
        {
            ShowPosition(L52.Name);
        }

        private void L53_Click(object sender, EventArgs e)
        {
            ShowPosition(L53.Name);
        }

        private void L54_Click(object sender, EventArgs e)
        {
            ShowPosition(L54.Name);
        }

        private void L61_Click(object sender, EventArgs e)
        {
            ShowPosition(L61.Name);
        }

        private void L62_Click(object sender, EventArgs e)
        {
            ShowPosition(L62.Name);
        }

        private void L63_Click(object sender, EventArgs e)
        {
            ShowPosition(L63.Name);
        }

        private void L64_Click(object sender, EventArgs e)
        {
            ShowPosition(L64.Name);
        }

        private void L71_Click(object sender, EventArgs e)
        {
            ShowPosition(L71.Name);
        }

        private void L72_Click(object sender, EventArgs e)
        {
            ShowPosition(L72.Name);
        }

        private void L73_Click(object sender, EventArgs e)
        {
            ShowPosition(L73.Name);
        }

        private void L74_Click(object sender, EventArgs e)
        {
            ShowPosition(L74.Name);
        }

        private void M11_Click(object sender, EventArgs e)
        {
            ShowPosition(M11.Name);
        }

        private void M12_Click(object sender, EventArgs e)
        {
            ShowPosition(M12.Name);
        }

        private void M13_Click(object sender, EventArgs e)
        {
            ShowPosition(M13.Name);
        }

        private void M14_Click(object sender, EventArgs e)
        {
            ShowPosition(M14.Name);
        }

        private void M21_Click(object sender, EventArgs e)
        {
            ShowPosition(M21.Name);
        }

        private void M22_Click(object sender, EventArgs e)
        {
            ShowPosition(M22.Name);
        }

        private void M23_Click(object sender, EventArgs e)
        {
            ShowPosition(M23.Name);
        }

        private void M24_Click(object sender, EventArgs e)
        {
            ShowPosition(M24.Name);
        }

        private void M31_Click(object sender, EventArgs e)
        {
            ShowPosition(M31.Name);
        }

        private void M32_Click(object sender, EventArgs e)
        {
            ShowPosition(M32.Name);
        }

        private void M33_Click(object sender, EventArgs e)
        {
            ShowPosition(M33.Name);
        }

        private void M34_Click(object sender, EventArgs e)
        {
            ShowPosition(M34.Name);
        }

        private void M41_Click(object sender, EventArgs e)
        {
            ShowPosition(M41.Name);
        }

        private void M42_Click(object sender, EventArgs e)
        {
            ShowPosition(M42.Name);
        }

        private void M43_Click(object sender, EventArgs e)
        {
            ShowPosition(M43.Name);
        }

        private void M44_Click(object sender, EventArgs e)
        {
            ShowPosition(M44.Name);
        }

        private void M51_Click(object sender, EventArgs e)
        {
            ShowPosition(M51.Name);
        }

        private void M52_Click(object sender, EventArgs e)
        {
            ShowPosition(M52.Name);
        }

        private void M53_Click(object sender, EventArgs e)
        {
            ShowPosition(M53.Name);
        }

        private void M54_Click(object sender, EventArgs e)
        {
            ShowPosition(M54.Name);
        }

        private void M61_Click(object sender, EventArgs e)
        {
            ShowPosition(M61.Name);
        }

        private void M62_Click(object sender, EventArgs e)
        {
            ShowPosition(M62.Name);
        }

        private void M63_Click(object sender, EventArgs e)
        {
            ShowPosition(M63.Name);
        }

        private void M64_Click(object sender, EventArgs e)
        {
            ShowPosition(M64.Name);
        }

        private void M71_Click(object sender, EventArgs e)
        {
            ShowPosition(M71.Name);
        }

        private void M72_Click(object sender, EventArgs e)
        {
            ShowPosition(M72.Name);
        }

        private void M73_Click(object sender, EventArgs e)
        {
            ShowPosition(M73.Name);
        }

        private void M74_Click(object sender, EventArgs e)
        {
            ShowPosition(M74.Name);
        }

        private void N11_Click(object sender, EventArgs e)
        {
            ShowPosition(N11.Name);
        }

        private void N12_Click(object sender, EventArgs e)
        {
            ShowPosition(N12.Name);
        }

        private void N13_Click(object sender, EventArgs e)
        {
            ShowPosition(N13.Name);
        }

        private void N14_Click(object sender, EventArgs e)
        {
            ShowPosition(N14.Name);
        }

        private void N21_Click(object sender, EventArgs e)
        {
            ShowPosition(N21.Name);
        }

        private void N22_Click(object sender, EventArgs e)
        {
            ShowPosition(N22.Name);
        }

        private void N23_Click(object sender, EventArgs e)
        {
            ShowPosition(N23.Name);
        }

        private void N24_Click(object sender, EventArgs e)
        {
            ShowPosition(N24.Name);
        }

        private void N31_Click(object sender, EventArgs e)
        {
            ShowPosition(N31.Name);
        }

        private void N32_Click(object sender, EventArgs e)
        {
            ShowPosition(N32.Name);
        }

        private void N33_Click(object sender, EventArgs e)
        {
            ShowPosition(N33.Name);
        }

        private void N34_Click(object sender, EventArgs e)
        {
            ShowPosition(N34.Name);
        }

        private void N41_Click(object sender, EventArgs e)
        {
            ShowPosition(N41.Name);
        }

        private void N42_Click(object sender, EventArgs e)
        {
            ShowPosition(N42.Name);
        }

        private void N43_Click(object sender, EventArgs e)
        {
            ShowPosition(N43.Name);
        }

        private void N44_Click(object sender, EventArgs e)
        {
            ShowPosition(N44.Name);
        }

        private void N51_Click(object sender, EventArgs e)
        {
            ShowPosition(N51.Name);
        }

        private void N52_Click(object sender, EventArgs e)
        {
            ShowPosition(N52.Name);
        }

        private void N53_Click(object sender, EventArgs e)
        {
            ShowPosition(N53.Name);
        }

        private void N54_Click(object sender, EventArgs e)
        {
            ShowPosition(N54.Name);
        }

        private void N61_Click(object sender, EventArgs e)
        {
            ShowPosition(N61.Name);
        }

        private void N62_Click(object sender, EventArgs e)
        {
            ShowPosition(N62.Name);
        }

        private void N63_Click(object sender, EventArgs e)
        {
            ShowPosition(N63.Name);
        }

        private void N64_Click(object sender, EventArgs e)
        {
            ShowPosition(N64.Name);
        }

        private void N71_Click(object sender, EventArgs e)
        {
            ShowPosition(N71.Name);
        }

        private void N72_Click(object sender, EventArgs e)
        {
            ShowPosition(N72.Name);
        }

        private void N73_Click(object sender, EventArgs e)
        {
            ShowPosition(N73.Name);
        }

        private void N74_Click(object sender, EventArgs e)
        {
            ShowPosition(N74.Name);
        }

        private void O11_Click(object sender, EventArgs e)
        {
            ShowPosition(O11.Name);
        }

        private void O12_Click(object sender, EventArgs e)
        {
            ShowPosition(O12.Name);
        }

        private void O13_Click(object sender, EventArgs e)
        {
            ShowPosition(O13.Name);
        }

        private void O14_Click(object sender, EventArgs e)
        {
            ShowPosition(O14.Name);
        }

        private void O21_Click(object sender, EventArgs e)
        {
            ShowPosition(O21.Name);
        }

        private void O22_Click(object sender, EventArgs e)
        {
            ShowPosition(O22.Name);
        }

        private void O23_Click(object sender, EventArgs e)
        {
            ShowPosition(O23.Name);
        }

        private void O24_Click(object sender, EventArgs e)
        {
            ShowPosition(O24.Name);
        }

        private void O31_Click(object sender, EventArgs e)
        {
            ShowPosition(O31.Name);
        }

        private void O32_Click(object sender, EventArgs e)
        {
            ShowPosition(O32.Name);
        }

        private void O33_Click(object sender, EventArgs e)
        {
            ShowPosition(O33.Name);
        }

        private void O34_Click(object sender, EventArgs e)
        {
            ShowPosition(O34.Name);
        }

        private void O41_Click(object sender, EventArgs e)
        {
            ShowPosition(O41.Name);
        }

        private void O42_Click(object sender, EventArgs e)
        {
            ShowPosition(O42.Name);
        }

        private void O43_Click(object sender, EventArgs e)
        {
            ShowPosition(O43.Name);
        }

        private void O44_Click(object sender, EventArgs e)
        {
            ShowPosition(O44.Name);
        }

        private void O51_Click(object sender, EventArgs e)
        {
            ShowPosition(O51.Name);
        }

        private void O52_Click(object sender, EventArgs e)
        {
            ShowPosition(O52.Name);
        }

        private void O53_Click(object sender, EventArgs e)
        {
            ShowPosition(O53.Name);
        }

        private void O54_Click(object sender, EventArgs e)
        {
            ShowPosition(O54.Name);
        }

        private void O61_Click(object sender, EventArgs e)
        {
            ShowPosition(O61.Name);
        }

        private void O62_Click(object sender, EventArgs e)
        {
            ShowPosition(O62.Name);
        }

        private void O63_Click(object sender, EventArgs e)
        {
            ShowPosition(O63.Name);
        }

        private void O64_Click(object sender, EventArgs e)
        {
            ShowPosition(O64.Name);
        }

        private void O71_Click(object sender, EventArgs e)
        {
            ShowPosition(O71.Name);
        }

        private void O72_Click(object sender, EventArgs e)
        {
            ShowPosition(O72.Name);
        }

        private void O73_Click(object sender, EventArgs e)
        {
            ShowPosition(O73.Name);
        }

        private void O74_Click(object sender, EventArgs e)
        {
            ShowPosition(O74.Name);
        }

        private void P11_Click(object sender, EventArgs e)
        {
            ShowPosition(P11.Name);
        }

        private void P12_Click(object sender, EventArgs e)
        {
            ShowPosition(P12.Name);
        }

        private void P13_Click(object sender, EventArgs e)
        {
            ShowPosition(P13.Name);
        }

        private void P14_Click(object sender, EventArgs e)
        {
            ShowPosition(P14.Name);
        }

        private void P21_Click(object sender, EventArgs e)
        {
            ShowPosition(P21.Name);
        }

        private void P22_Click(object sender, EventArgs e)
        {
            ShowPosition(P22.Name);
        }

        private void P23_Click(object sender, EventArgs e)
        {
            ShowPosition(P23.Name);
        }

        private void P24_Click(object sender, EventArgs e)
        {
            ShowPosition(P24.Name);
        }

        private void P31_Click(object sender, EventArgs e)
        {
            ShowPosition(P31.Name);
        }

        private void P32_Click(object sender, EventArgs e)
        {
            ShowPosition(P32.Name);
        }

        private void P33_Click(object sender, EventArgs e)
        {
            ShowPosition(P33.Name);
        }

        private void P34_Click(object sender, EventArgs e)
        {
            ShowPosition(P34.Name);
        }

        private void P41_Click(object sender, EventArgs e)
        {
            ShowPosition(P41.Name);
        }

        private void P42_Click(object sender, EventArgs e)
        {
            ShowPosition(P42.Name);
        }

        private void P43_Click(object sender, EventArgs e)
        {
            ShowPosition(P43.Name);
        }

        private void P44_Click(object sender, EventArgs e)
        {
            ShowPosition(P44.Name);
        }

        private void P51_Click(object sender, EventArgs e)
        {
            ShowPosition(P51.Name);
        }

        private void P52_Click(object sender, EventArgs e)
        {
            ShowPosition(P52.Name);
        }

        private void P53_Click(object sender, EventArgs e)
        {
            ShowPosition(P53.Name);
        }

        private void P54_Click(object sender, EventArgs e)
        {
            ShowPosition(P54.Name);
        }

        private void P61_Click(object sender, EventArgs e)
        {
            ShowPosition(P61.Name);
        }

        private void P62_Click(object sender, EventArgs e)
        {
            ShowPosition(P62.Name);
        }

        private void P63_Click(object sender, EventArgs e)
        {
            ShowPosition(P63.Name);
        }

        private void P64_Click(object sender, EventArgs e)
        {
            ShowPosition(P64.Name);
        }

        private void P71_Click(object sender, EventArgs e)
        {
            ShowPosition(P71.Name);
        }

        private void P72_Click(object sender, EventArgs e)
        {
            ShowPosition(P72.Name);
        }

        private void P73_Click(object sender, EventArgs e)
        {
            ShowPosition(P73.Name);
        }

        private void P74_Click(object sender, EventArgs e)
        {
            ShowPosition(P74.Name);
        }

        private void R11_Click(object sender, EventArgs e)
        {
            ShowPosition(R11.Name);
        }

        private void R12_Click(object sender, EventArgs e)
        {
            ShowPosition(R12.Name);
        }

        private void R13_Click(object sender, EventArgs e)
        {
            ShowPosition(R13.Name);
        }

        private void R14_Click(object sender, EventArgs e)
        {
            ShowPosition(R14.Name);
        }

        private void R21_Click(object sender, EventArgs e)
        {
            ShowPosition(R21.Name);
        }

        private void R22_Click(object sender, EventArgs e)
        {
            ShowPosition(R22.Name);
        }

        private void R23_Click(object sender, EventArgs e)
        {
            ShowPosition(R23.Name);
        }

        private void R24_Click(object sender, EventArgs e)
        {
            ShowPosition(R24.Name);
        }

        private void R31_Click(object sender, EventArgs e)
        {
            ShowPosition(R31.Name);
        }

        private void R32_Click(object sender, EventArgs e)
        {
            ShowPosition(R32.Name);
        }

        private void R33_Click(object sender, EventArgs e)
        {
            ShowPosition(R33.Name);
        }

        private void R34_Click(object sender, EventArgs e)
        {
            ShowPosition(R34.Name);
        }

        private void R41_Click(object sender, EventArgs e)
        {
            ShowPosition(R41.Name);
        }

        private void R42_Click(object sender, EventArgs e)
        {
            ShowPosition(R42.Name);
        }

        private void R43_Click(object sender, EventArgs e)
        {
            ShowPosition(R43.Name);
        }

        private void R44_Click(object sender, EventArgs e)
        {
            ShowPosition(R44.Name);
        }

        private void R51_Click(object sender, EventArgs e)
        {
            ShowPosition(R51.Name);
        }

        private void R52_Click(object sender, EventArgs e)
        {
            ShowPosition(R52.Name);
        }

        private void R53_Click(object sender, EventArgs e)
        {
            ShowPosition(R53.Name);
        }

        private void R54_Click(object sender, EventArgs e)
        {
            ShowPosition(R54.Name);
        }

        private void R61_Click(object sender, EventArgs e)
        {
            ShowPosition(R61.Name);
        }

        private void R62_Click(object sender, EventArgs e)
        {
            ShowPosition(R62.Name);
        }

        private void R63_Click(object sender, EventArgs e)
        {
            ShowPosition(R63.Name);
        }

        private void R64_Click(object sender, EventArgs e)
        {
            ShowPosition(R64.Name);
        }

        private void R71_Click(object sender, EventArgs e)
        {
            ShowPosition(R71.Name);
        }

        private void R72_Click(object sender, EventArgs e)
        {
            ShowPosition(R72.Name);
        }

        private void R73_Click(object sender, EventArgs e)
        {
            ShowPosition(R73.Name);
        }

        private void R74_Click(object sender, EventArgs e)
        {
            ShowPosition(R74.Name);
        }

        private void S01_Click(object sender, EventArgs e)
        {
            ShowPosition(S01.Name);
        }

        private void S02_Click(object sender, EventArgs e)
        {
            ShowPosition(S02.Name);
        }

        private void S03_Click(object sender, EventArgs e)
        {
            ShowPosition(S03.Name);
        }

        private void S04_Click(object sender, EventArgs e)
        {
            ShowPosition(S04.Name);
        }

        private void S11_Click(object sender, EventArgs e)
        {
            ShowPosition(S11.Name);
        }

        private void S12_Click(object sender, EventArgs e)
        {
            ShowPosition(S12.Name);
        }

        private void S13_Click(object sender, EventArgs e)
        {
            ShowPosition(S13.Name);
        }

        private void S14_Click(object sender, EventArgs e)
        {
            ShowPosition(S14.Name);
        }

        private void S21_Click(object sender, EventArgs e)
        {
            ShowPosition(S21.Name);
        }

        private void S22_Click(object sender, EventArgs e)
        {
            ShowPosition(S22.Name);
        }

        private void S23_Click(object sender, EventArgs e)
        {
            ShowPosition(S23.Name);
        }

        private void S24_Click(object sender, EventArgs e)
        {
            ShowPosition(S24.Name);
        }

        private void S31_Click(object sender, EventArgs e)
        {
            ShowPosition(S31.Name);
        }

        private void S32_Click(object sender, EventArgs e)
        {
            ShowPosition(S32.Name);
        }

        private void S33_Click(object sender, EventArgs e)
        {
            ShowPosition(S33.Name);
        }

        private void S34_Click(object sender, EventArgs e)
        {
            ShowPosition(S34.Name);
        }

        private void S41_Click(object sender, EventArgs e)
        {
            ShowPosition(S41.Name);
        }

        private void S42_Click(object sender, EventArgs e)
        {
            ShowPosition(S42.Name);
        }

        private void S43_Click(object sender, EventArgs e)
        {
            ShowPosition(S43.Name);
        }

        private void S44_Click(object sender, EventArgs e)
        {
            ShowPosition(S44.Name);
        }

        private void S51_Click(object sender, EventArgs e)
        {
            ShowPosition(S51.Name);
        }

        private void S52_Click(object sender, EventArgs e)
        {
            ShowPosition(S52.Name);
        }

        private void S53_Click(object sender, EventArgs e)
        {
            ShowPosition(S53.Name);
        }

        private void S54_Click(object sender, EventArgs e)
        {
            ShowPosition(S54.Name);
        }

        private void S61_Click(object sender, EventArgs e)
        {
            ShowPosition(S61.Name);
        }

        private void S62_Click(object sender, EventArgs e)
        {
            ShowPosition(S62.Name);
        }

        private void S63_Click(object sender, EventArgs e)
        {
            ShowPosition(S63.Name);
        }

        private void S64_Click(object sender, EventArgs e)
        {
            ShowPosition(S64.Name);
        }

        private void S71_Click(object sender, EventArgs e)
        {
            ShowPosition(S71.Name);
        }

        private void S72_Click(object sender, EventArgs e)
        {
            ShowPosition(S72.Name);
        }

        private void S73_Click(object sender, EventArgs e)
        {
            ShowPosition(S73.Name);
        }

        private void S74_Click(object sender, EventArgs e)
        {
            ShowPosition(S74.Name);
        }
        #endregion
    
    }
}
