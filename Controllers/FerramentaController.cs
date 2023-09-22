using Microsoft.AspNetCore.Mvc;
using SoftwareControle.Models;
using SoftwareControle.Repositories.Interfaces;

namespace SoftwareControle.Controllers
{
    public class FerramentaController : Controller
    {
        private readonly IFerramentaRepository _ferramentaRepository;

        public FerramentaController(IFerramentaRepository ferramentaRepository)
        {
            _ferramentaRepository = ferramentaRepository;
        }

        public IActionResult Index()
        {
            var ferramentas = _ferramentaRepository.GetFerramentas();
            return View(ferramentas);
        }

        public IActionResult Adicionar()
        {
            return View();
        }

        [HttpPost]
                                                                                    //IActionResult:    O tipo de retorno da ação. Neste caso, estamos retornando um objeto IActionResult, que é usado para representar
                                                                                   //o resultado de uma ação em um controlador ASP.NET Core.


                                                                                 //Adicionar:     O nome da ação. Esse nome é usado para mapear uma solicitação HTTP para esta ação específica. Por exemplo, se você acessar essa ação através de uma solicitação HTTP POST
                                                                                //para "/Ferramenta/Adicionar", essa ação será acionada.

                                                                               //Ferramenta ferramenta:   Isso é um parâmetro do tipo Ferramenta, que representa o modelo de dados da ferramenta que será adicionada.

                                                                              //IFormFile imagem:    Isso é um parâmetro do tipo IFormFile, que representa a imagem que está sendo enviada no formulário. 
        public IActionResult Adicionar(Ferramenta ferramenta,IFormFile imagem)
        {

                                   //if (ModelState.IsValid) você está verificando se todas as regras de validação definidas no modelo (como atributos de validação nos campos do modelo) foram satisfeitas. Se todas as regras de
                                  //validação forem atendidas, ModelState.IsValid retornará true. Caso contrário, se pelo menos uma regra de validação não for satisfeita, ModelState.IsValid retornará false.
            if (ModelState.IsValid) 
            {

                if (imagem != null)
                {                                     //using (var memoryStream = new MemoryStream()): Isso cria um novo MemoryStream, que é uma classe que permite trabalhar com dados na memória. O using garante que o MemoryStream será liberado
                                                      //corretamente após seu uso.
                    using (var memoryStream = new MemoryStream())

                    {                               //imagem.CopyTo(memoryStream): Isso copia o conteúdo do arquivo de imagem (imagem) para o MemoryStream. O CopyTo é um método que copia os dados de um fluxo para outro.
                        imagem.CopyTo(memoryStream);

                        //ferramenta.Imagem = memoryStream.ToArray(): Aqui, estamos atribuindo o array de bytes que representa o conteúdo da imagem no MemoryStream para a propriedade Imagem da entidade ferramenta.
                                                                   //O método ToArray() converte os dados do MemoryStream em um array de bytes.
                        ferramenta.Imagem = memoryStream.ToArray();

                    }
                }                             
                _ferramentaRepository.AddFerramenta(ferramenta,ferramenta.Imagem);//_ferramentaRepository.AddFerramenta(ferramenta, ferramenta.Imagem);: Aqui você está chamando o método AddFerramenta do repositório _ferramentaRepository. Esse método tem dois parâmetros: ferramenta e imagem. O primeiro parâmetro, ferramenta, é o objeto que você deseja adicionar ao banco de dados, e o segundo parâmetro, imagem, é o array de bytes da imagem associada a essa ferramenta. Ao chamar esse método, você está passando esses dois valores para o repositório, para que ele possa adicionar a ferramenta ao banco de dados.
                return RedirectToAction("Index");  

            }


            return View(ferramenta);

        }






        public IActionResult Alterar(int id)  //public IActionResult Alterar(int id): Declaração do método Alterar que recebe um parâmetro id.
        {
            var ferramenta = _ferramentaRepository.GetFerramentaById(id); //var ferramenta = _ferramentaRepository.GetFerramentaById(id);: Busca a ferramenta no repositório pelo ID fornecido.

            if (ferramenta == null) //Verifica se a ferramenta não foi encontrada no banco de dados.
            {
                return NotFound(); // Retorna uma página de erro se a ferramenta não for encontrada
            }

            return View(ferramenta);// Se a ferramenta for encontrada, retorna a view Alterar passando a ferramenta como modelo.
        }



        [HttpPost]// [HttpPost]: Atributo que indica que este método deve ser chamado quando um formulário for submetido via POST.
        public IActionResult Alterar(Ferramenta ferramenta, IFormFile imagem)//public IActionResult: Indica que o método retorna um tipo de resultado do tipo IActionResult, que é usado para representar o resultado de uma ação em um controlador ASP.NET Core.Alterar: É o nome do método. Este método lida com a ação de alteração de uma ferramenta.(Ferramenta ferramenta, IFormFile imagem): Estes são os parâmetros do método.
        {
            if (ModelState.IsValid)// if (ModelState.IsValid): Verifica se o estado do modelo é válido (se todas as regras de validação foram atendidas).
            {
                if (imagem != null) //if (imagem != null): Verifica se uma nova imagem foi enviada no formulário.
                {
                    using (var memoryStream = new MemoryStream()) //using (var memoryStream = new MemoryStream()): Cria um MemoryStream para armazenar temporariamente a nova imagem.
                    {
                        imagem.CopyTo(memoryStream);// imagem.CopyTo(memoryStream): Copia o conteúdo da imagem para o memoryStream.
                        ferramenta.Imagem = memoryStream.ToArray();// ferramenta.Imagem = memoryStream.ToArray(): Atribui o conteúdo do memoryStream como a imagem da ferramenta.
                    }
                }

                _ferramentaRepository.UpdateFerramenta(ferramenta, ferramenta.Imagem);
                return RedirectToAction("Index");//_ferramentaRepository.UpdateFerramenta(ferramenta, ferramenta.Imagem): Chama o método UpdateFerramenta no repositório para atualizar a ferramenta no banco de dados.
            }

            return View(ferramenta);
        }






        public IActionResult Excluir(int id)  //public IActionResult Excluir(int id): A assinatura do método Excluir, indicando que ele retorna um tipo de resultado IActionResult e aceita um parâmetro id do tipo int, que representa o ID da ferramenta a ser excluída.
        {
            var ferramenta = _ferramentaRepository.GetFerramentaById(id);//var ferramenta = _ferramentaRepository.GetFerramentaById(id);: Aqui, é recuperada a ferramenta específica com base no ID fornecido. Isso é feito chamando o método GetFerramentaById do repositório _ferramentaRepository e passando o ID como parâmetro. A ferramenta recuperada é armazenada na variável ferramenta.

            if (ferramenta == null)//if (ferramenta == null): Verifica se a variável ferramenta está nula, ou seja, se a ferramenta com o ID fornecido não foi encontrada.
            {
                return NotFound(); // Retorna uma página de erro se a ferramenta não for encontrada
            }

            return View(ferramenta);
        }




        [HttpPost, ActionName("Excluir")]
        public IActionResult ConfirmarExclusao(int id) //A assinatura do método ConfirmarExclusao, indicando que ele retorna um tipo de resultado IActionResult e aceita um parâmetro id do tipo int, que representa o ID da ferramenta a ser excluída
        {
            var ferramenta = _ferramentaRepository.GetFerramentaById(id);//var ferramenta = _ferramentaRepository.GetFerramentaById(id);: Aqui, é recuperada a ferramenta específica com base no ID fornecido, da mesma forma que na ação Excluir.

            if (ferramenta == null)//Verifica se a variável ferramenta está nula, ou seja, se a ferramenta com o ID fornecido não foi encontrada.
            {
                return NotFound(); // Retorna uma página de erro se a ferramenta não for encontrada
            }

            _ferramentaRepository.DeleteFerramenta(ferramenta);//_ferramentaRepository.DeleteFerramenta(ferramenta);: Se a ferramenta for encontrada, a ação chama o método DeleteFerramenta do repositório 
            return RedirectToAction("Index");
        }




    }
}
