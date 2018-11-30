using App01_ConsultarCEP.Servico;
using App01_ConsultarCEP.Servico.Modelo;
using System;
using Xamarin.Forms;
using App01_ConsultarCEP.Servico.Modelo;
using App01_ConsultarCEP.Servico;


namespace App01_ConsultarCEP
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            BOTAO.Clicked += BuscarCEP;

        }


        private void BuscarCEP(object sender, EventArgs args)
        {
            //TODO -LÓGICA DO PROGRMA


            //TODO -VALIDAÇÕES
            string cep = CEP.Text.Trim();

            if (isValidCEP(cep))
            {
                Endereco end = ViaCEPServico.BuscarEnderecoViaCEP(cep);

                RESULTADO.Text = string.Format("Endereço {2},{3},{0},{1}", end.localidade, end.uf, end.logradouro, end.bairro);
            }

        }

        private bool isValidCEP(string cep)
        {

            bool valido = true;

            if (cep.Length != 8)
            {

                DisplayAlert("ERRO", "CEP inválido! O CEP deve conter 8 caracteres.", "OK");
                //erro
                valido = false;
            }
            int NovoCEP = 0;
            if (!int.TryParse(cep, out NovoCEP))
            {
                DisplayAlert("ERRO", "CEP inválido! O CEP deve ser composto apenas por números", "OK");
                valido = false;
            }

            return valido;
        }
    }
}
