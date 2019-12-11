                                                  Sorular


-Projede kullandığınız tasarım desenleri hangileridir? Bu desenleri neden kullandınız?
  
  Projede repository tasarım deseni kullandım. Bu deseni projede kullanma sebeplerimden biri sizlerin talebi bu yönde olduğu için, bir diğeri de; bu yaklaşım veriye tek yerden ulaşımı sağladı. Ayrıca generic bir yapı olduğu için her bir entity için ayrı ayrı veritabanı işlemi yapmak yerine repository interfacesini miras alan her class(bu projede manager classı) bu özelliklere sahip oldu ve kod tekrarının önüne geçti. Ayrıca entityframework metotlarını abstract etmiş oldum.


-Kullandığınız teknoloji ve kütüphaneler hakkında daha önce tecrübeniz oldu mu? Tek tek yazabilir misiniz?
  
  ASP.Net Web API ile ilgili daha önce proje geliştirmiştim ama Asp.Net Core ile ilgili daha önce bir tecrübem olmamıştı. Bu projeyi yapmadan önce başlangıç düzeyinde bir tecrübem vardı. Entity Framework daha önce kullanmıştım ama Entity Framework Core'u ilk defa kullandım. 


-Daha geniş vaktiniz olsaydı projeye neler eklemek isterdiniz?
  
  Daha geniş bir vaktim olsaydı, projede istenen blog veritabanının tamamını tasarlardım. Ayrıca API kısmına authantication ve token mekanizması oluştururdum. API metotları için kendime ait özel dönüş modeli tasarlardım. Bunları oluşturduktan sonra React.JS veya Vue.JS gibi (veya Asp.Net Mvc projesi olacaksa Angular kütüphanesini) günümüzde avantajlar sağlayan Javascript frameworklerinden birini kullanarak API'ı tüketebileceğim bir UI tasarlardım.



-Eklemek istediğiniz bir yorumunuz var mı?

  Mülakattan önce böyle bir case verilmesi güzel bir uygulama olmuş. Başlangıç düzeyince bilgim olan bir teknolojiyi kullanarak küçük bir uygulama yapma şansı edindim bu sayede ASP.NET Core teknolojisini tanımış oldum. Teşekkür ederim.
    
    
   
________________________________________________________________________________________________________________________________________


                                    API kullanım dökümantasyonu
                                    
string baseUrl = "http://localhost:xxxxx/"

  1.) "baseUrl" + api/article/list => bütün makaleleri listeler
  
  2.) "baseUrl" + api/article/getsingle/{id} => Idsi verilen makaleyi döndürür.(kayıt bulunamaması durumunda NotFound("Gelen parametreye ait makale bulunamadı!") döner. )
  
  3.) "baseUrl" + api/article/post => makale ekler. Model olarak [FromBody] aşağıdaki şekilde bir obje ister.
  
            {
              "ImagePath": "test3.jpg",
              "Subject": "Test 3 Makale",
              "Content": "Test 3 İçerik",
              "Date" : "2019-10-12",
              "Author": "Ertan Kanter",
              "IsActive" : true
            }
            
        
  4.) "baseUrl" + api/article/update/{id} => Idsi verilen makaleyi günceller. Model olarak [FromBody] aşağıdaki şekilde bir obje ister.
  
            {
              "ImagePath": "test3.jpg",
              "Subject": "Test 3 Makale",
              "Content": "Test 3 İçerik",
              "Date" : "2019-10-12",
              "Author": "Ertan Kanter",
              "IsActive" : true
            }
            
        
  5.) "baseUrl" + api/article/delete/{id} => Idsi verilen makaleyi siler.
  
  6.) "baseUrl" + api/article/search/{data} => girilen parametreye göre filtrelenen makalelerin listesini döner.  
  
