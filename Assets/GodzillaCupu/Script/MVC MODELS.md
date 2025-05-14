Struktur MVC yang di terapkan 

-> User Input / Events 
    -> Controller [Terima Input, Validasi, Ubah Model]
            |
            |
            V
    -> Model [Data, Logic, Emit event / data change] <------------------+
            |                                                           |
            |                                                           |
            V                                                           |
    [Event : OnModelsChanged]                                           |
            |                                                           |
            |                                                           |
            V                                                           |
    -> View [Update UI, Dengarkan perubahan model] <--------------------+


Penjelasan : 
[Model] Bertugas sebagai containner data (menyiapkan,menyimpan) serta containner LOGIC untuk mengatur/memanipulasi dan mengorganisir data
    -> Data
    -> Logic
[View] Bertugas Menampilkan data dalam bentuk ui / lain nya, / mengatur segala sesuatu yang berhubungan dengan interface
    -> GUI
    -> UI, Animations, etc
[Controller] Bertugas untuk Menghubungankan View dan Model
    -> Handle Input
    -> Connecting model and view

Contoh implementasi dapat diliat pada movement player [[PlayerMovement](Player/movement)]