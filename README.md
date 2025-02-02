# Unity'de State Machine

## Genel Bakış

Bu proje, Unity'de bir karakterin animasyonlarını (yürüyüş, dash, saldırı, durma vb.) yönetmek için state machine (durum makinesi) tasarım deseninin nasıl kullanılacağını gösterir. State machine, karakterin farklı durumlar arasında sorunsuz geçişler yapmasını sağlar ve bu geçişler, kullanıcı girdilerine veya oyun koşullarına bağlı olarak gerçekleşir.

## State Machine Nedir?

State machine, bir nesnenin (bu projede karakter) farklı durumlar arasında geçiş yapmasını sağlayan bir tasarım desenidir. Her durum, nesnenin bir davranışını veya koşulunu temsil eder. State machine, nesnenin hangi durumda olduğunu ve bir durumdan diğerine nasıl geçeceğini kontrol eder.

Örneğin, bu projede karakter aşağıdaki durumlar arasında geçiş yapabilir:

- **Idle (Durma)**: Karakter hareketsiz duruyor.
- **Walking (Yürüme)**: Karakter normal hızda hareket ediyor.
- **Dashing (Dash)**: Karakter kısa süreli bir hız artışıyla hareket ediyor.
- **Attacking (Saldırı)**: Karakter bir saldırı animasyonu gerçekleştiriyor.

Her bir durumun kendine ait bir davranışı (örneğin animasyonlar veya aksiyonlar) vardır ve state machine, doğru durumu aktif hale getirerek animasyonları kontrol eder.

## Animasyonlarda State Machine Kullanımının Amacı

State machine, animasyonları yönetmek için düzenli ve verimli bir yöntem sağlar. State machine kullanmadan animasyonlar arasında geçiş yapmak karmaşık hale gelebilir ve kod yönetimi zorlaşabilir. State machine, karakterin eylemlerine ve koşullarına bağlı olarak animasyonları düzgün bir şekilde geçiştirmek için kullanılır.

Bu proje, her animasyonun (Idle, Walking, Dashing, Attacking) kendi durumunda bağımsız olarak kontrol edilmesini sağlar ve durumlar arasında geçiş yapmayı kolaylaştırır.


