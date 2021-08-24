﻿using Domain;
using FrmLogin.FrmEnter;
using FrmLogin.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrmLogin.Controllers
{
    public class EntranceController
    {
        public EntranceController()
        {

        }

        public Client Client { get; set; }
        public Roba Roba { get; set; }
        public Entrance Entrance { get; set; }
        public List<EntranceItems> Items { get; set; } = new List<EntranceItems>();

        public BindingList<EntranceItems> bindingList = new BindingList<EntranceItems>();
        internal void OpenFrmEnterClient(FrmEntrance frmEntrance)
        {
            FrmEnterClient frmEnterClient = new FrmEnterClient(frmEntrance, new Controllers.ClientsController());
            frmEnterClient.ShowDialog();
        }

        internal void OpenFrmEnterArtikal(FrmEntrance frmEntrance)
        {
            if (UserControlHelpers.IsNullOrWhiteSpace(frmEntrance.TxtClient))
            {
                MessageBox.Show("Greska!! Morate prvo uneti klijenta.");
                return;
            }
            FrmEnterArtikal frmEnterArtikal = new FrmEnterArtikal(frmEntrance, new Controllers.RobaController());
            frmEnterArtikal.ShowDialog();
        }

        internal void AddItems(FrmEntrance frmEntrance)
        {
            var culture = new CultureInfo("de-DE");

            if (UserControlHelpers.IsNullOrWhiteSpace(frmEntrance.TxtArtikal) | UserControlHelpers.IsNullOrWhiteSpace(frmEntrance.TxtDateOfManu)
                | UserControlHelpers.IsNullOrWhiteSpace(frmEntrance.TxtQuantity))
            {
                return;
            }
            try
            {
                Client = Communication.Communication.Instance.ReturnClient(frmEntrance.TxtClient.Text);
                Roba = Communication.Communication.Instance.ReturnRoba(frmEntrance.TxtArtikal.Text);

                Entrance ulaz = new Entrance
                {
                    DateOfEntrance = frmEntrance.EntranceDate,
                    Dimension = frmEntrance.RTxtDimension.Text,
                    ClientId = Client.ClientId,
                    Storekeeper = Controllers.LoginController.Storekeeper,
                };

                Entrance = ulaz;
                EntranceItems ei = new EntranceItems
                {
                    Num = int.Parse(frmEntrance.TxtNum.Text),
                    Roba = Roba,
                    RobaId = Roba.RobaId,
                    DateOfManu = DateTime.ParseExact(frmEntrance.TxtDateOfManu.Text, "dd.MM.yyyy.", culture),
                    DeadlineDate = DateTime.ParseExact(frmEntrance.TxtDateOfManu.Text, "dd.MM.yyyy.", culture).AddYears(1),
                    NumOfBoxes = float.Parse(frmEntrance.TxtQuantity.Text)
                };
                Items.Add(ei);
                bindingList.Add(ei);
                NewItemReload1(ei,frmEntrance);
                frmEntrance.LblTotalWeight.Text = GetTotalWeight().ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        internal void Save(FrmEntrance frmEntrance)
        {
            if (string.IsNullOrEmpty(frmEntrance.LblTotalWeight.Text))
            {
                MessageBox.Show("Nema podataka!");
                return;
            }

            double TotalWeight = double.Parse(frmEntrance.LblTotalWeight.Text);

            try
            {
                Entrance.TotalWeight = TotalWeight;
                Entrance.Items = Items;
                Communication.Communication.Instance.AddEntrance(Entrance);
                MessageBox.Show("Uspešno sačuvan");
                frmEntrance.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void NewItemReload1(EntranceItems ei, FrmEntrance frmEntrance)
        {
            FrmEntrance.num += 1;
            frmEntrance.TxtNum.Text = FrmEntrance.num.ToString();
            frmEntrance.TxtQuantity.Text = "";
            frmEntrance.TxtDateOfEntrance.Text = "";
            frmEntrance.TxtArtikal.Text = "";
            frmEntrance.DGVItems.DataSource = bindingList;
            frmEntrance.DGVItems.Columns["EntranceId"].Visible = false;
            frmEntrance.DGVItems.Columns["DeadlineDate"].HeaderText = "Rok trajanja";
            frmEntrance.DGVItems.Columns["DateOfManu"].HeaderText = "Datum proizvodnje";
            frmEntrance.DGVItems.Columns["RobaId"].Visible = false;
            frmEntrance.DGVItems.Columns["Deadline"].Visible = false;

        }

        internal void RemoveFromList(FrmEntrance frmEntrance)
        {
            if (frmEntrance.DGVItems.Rows.Count == 0)
            {
                MessageBox.Show("Nema podataka");
                return;
            }
            try
            {
                EntranceItems ei = new EntranceItems();
                DataGridViewRow row = frmEntrance.DGVItems.SelectedRows[0];
                ei = (EntranceItems)row.DataBoundItem;
                bindingList.Remove(ei);
                Items.Remove(ei);
                frmEntrance.LblTotalWeight.Text = GetTotalWeight().ToString();
                NewItemReload2(Items,frmEntrance);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        public void NewItemReload2(List<EntranceItems> items, FrmEntrance frmEntrance)
        {
            for (int i = 0; i < items.Count; i++)
            {
                items[i].Num = i + 1;
            }
            FrmEntrance.num -= 1;
            frmEntrance.TxtNum.Text = FrmEntrance.num.ToString();
            frmEntrance.TxtQuantity.Text = "";
            frmEntrance.TxtDateOfEntrance.Text = "";
            frmEntrance.TxtArtikal.Text = "";
            frmEntrance.DGVItems.DataSource = bindingList;
        }

        public double GetTotalWeight()
        {
            double suma = 0;
            foreach (EntranceItems ei in bindingList)
            {
                suma += ei.NumOfBoxes * Communication.Communication.Instance.GetWeightOfBox(ei.RobaId);
            }
            return suma;
        }

    }
}
