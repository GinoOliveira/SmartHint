using System;
using System.Text.Json;

namespace SmartHint.Helppers
{
    public static class Extensions
    {

        public static string? GetValue(this JsonElement str, string Valor)
        {
            JsonElement elemento;
            if (str.TryGetProperty(Valor, out elemento))
            {
                return str.GetProperty(Valor).ToString();
            }
            else
            {
                return null;
            }

        }

        //        $.get(window.location.origin + "Home/BuscaRloc/" + 14918, function(data){

        //            console.log(JSON.parse(data));
        //        });



        // $.ajax({
        //        method: "POST",
        //            dataType: 'json',
        //            contentType: 'application/json',
        //            url: "@(Url.Action("ObterOpcao", "CheckList"))",
        //            data: JSON.stringify({
        //            ChecklistId: "@(ViewBag.id)",
        //                PerguntaId: 0,
        //                id: 0
        //            }),
        //            success: function(data) {

        //            },
        //            error: function (params) {

        //            }
        //});
    }
}
