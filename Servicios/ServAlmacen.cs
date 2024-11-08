using Microsoft.JSInterop;
using PracticaTareas.Modelos;
using System.Text.Json;

namespace PracticaTareas.Servicios
{
    public class ServAlmacen
    {
        private readonly IJSRuntime JsAlmacena;
        public List<Nota> LstNotas { get; private set; } = new List<Nota>();
        private Random random = new Random();
        private List<string> Memos = new List<string>
        {
            "../css/Img/Memo1.png",
            "../css/Img/Memo2.png",
            "../css/Img/Memo3.png",
            "../css/Img/Memo4.png",
            "../css/Img/Memo5.png",
            "../css/Img/Memo6.png",
            "../css/Img/Memo7.png",
            "../css/Img/Memo8.png",
            "../css/Img/Memo9.png",
            "../css/Img/Memo.png"
        };

        public ServAlmacen(IJSRuntime JsAl)
        {
            JsAlmacena = JsAl;
        }

        private string MemoAleatorio()
        {
            int i = random.Next(Memos.Count);
            return Memos[i];
        }


        public Nota NuevaNota()
        {
            return new Nota();
        }
        public async Task GuardaAlmNota(Nota nt)
        {
            if (!string.IsNullOrWhiteSpace(nt.Nombre) || !string.IsNullOrWhiteSpace(nt.Descripcion))
            {
                if (nt.img.Equals(""))
                {
                    nt.img = MemoAleatorio();
                }
                string NotaJs = JsonSerializer.Serialize(nt);
                await JsAlmacena.InvokeVoidAsync("localStorage.setItem", nt.Id.ToString(), NotaJs);
                await DesplegarNotas();
            }
        }

        private async Task<Nota> ObtenerAlmNota(string id)
        {
            string NotaJs = await JsAlmacena.InvokeAsync<string>("localStorage.getItem", id);
            return JsonSerializer.Deserialize<Nota>(NotaJs);
        }

        public async Task<List<Nota>> LstNotasGuardadas()
        {
            var IdNota = await JsAlmacena.InvokeAsync<string[]>("eval", "Object.keys(localStorage)");

            List<Nota> notas = new List<Nota>();

            foreach (var i in IdNota)
            {
                notas.Add(await ObtenerAlmNota(i));
            }
            return notas;
        }
        public async Task EliminaAlmNota(string id)
        {
            await JsAlmacena.InvokeVoidAsync("localStorage.removeItem", id);
            await DesplegarNotas();
        }

        public async Task CheckNota(Nota nt)
        {
            await GuardaAlmNota(nt);
            await DesplegarNotas();
        }

        public async void ArchivaNota(Nota nt)
        {
            if (!nt.Equals(null))
            {
                nt.Archiva = !nt.Archiva;
                await GuardaAlmNota(nt);
            }
        }

        public async Task DesplegarNotas()
        {
            LstNotas = await LstNotasGuardadas();
        }

    }
}
