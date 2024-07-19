var arr_hinh = [
    "~/assets/img/san_pham/sach3.jfif",
    "~/assets/img/san_pham/sach3-1.jfif",
    "~/assets/img/san_pham/sach3-2.jfif",
    "~/assets/img/san_pham/sach3-3.jfif",
    "~/assets/img/san_pham/sach3-4.jfif"
];
var vitri = 0;
    function next() {
        vitri++;
        if(vitri == arr_hinh.length) vitri = 0;
        document.getElementById("hinh").src=arr_hinh[vitri];
        document.getElementById("mota").innerText=arr_mota[vitri]
    }

// tự động chuyển slide trong 5 giây
    setInterval("next()",3000);

// đặt hàng
let count = 1;
const value = document.querySelector("#value");
const btns = document.querySelectorAll(".btn");

btns.forEach(function(btn){
    btn.addEventListener("click", function(e){
        const styles = e.currentTarget.classList;
        if(styles.contains("decrease")) {
            count++;
        }
        if(styles.contains("increase"))
        {
            count--;
            if(count<=0)
            {
                count=1;
            }
        }
        value.textContent = count;
    })
})