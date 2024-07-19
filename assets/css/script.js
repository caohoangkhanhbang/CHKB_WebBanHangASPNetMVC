
var arr_hinh = [
    "/assets/img/sach.jfif",
    "/assets/img/sach2.jfif",
    "/assets/img/thoiTangNam.png",
    "/assets/img/thoiTrang1.jpg",
    "/assets/img/thoiTrangNu.png"
];
var arr_mota = [
    "Sách dành cho thiếu nhi",
    "Sách dành cho thiếu nhi",
    "Thời trang nam",
    "Thời trang nữ",
    "Thời trang nữ"
]

var vitri = 0;


    function prev() {
        vitri--;
        if(vitri < 0 ) vitri = arr_hinh.length-1;
        document.getElementById("hinh").src=arr_hinh[vitri];
        document.getElementById("mota").innerText=arr_mota[vitri];
    }

    function next() {
        vitri++;
        if(vitri == arr_hinh.length) vitri = 0;
        document.getElementById("hinh").src=arr_hinh[vitri];
        document.getElementById("mota").innerText=arr_mota[vitri]
    }


// tự động chuyển slide trong 5 giây
    setInterval("next()",5000);