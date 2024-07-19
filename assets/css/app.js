window.addEventListener('scroll', e => {
	document.documentElement.style.setProperty('--scrollTop', `${this.scrollY}px`) // Update method
})
gsap.registerPlugin(ScrollTrigger, ScrollSmoother)
ScrollSmoother.create({
	wrapper: '.wrapper',
	content: '.content'
})

// ẩn hiện
let listTab = document.querySelectorAll('.tab')

window.addEventListener('scroll', (event) => {
	let top = this.scrollY;

	listTab.forEach(tab => {
	   if(tab.offsetTop - top < 5) {
		   tab.classList.add('active');
	   }
	   else {
		   tab.classList.remove('active')
	   }
	   
	});
})
