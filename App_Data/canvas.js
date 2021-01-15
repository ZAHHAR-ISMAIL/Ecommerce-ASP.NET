var canvas= document.querySelector('canvas');
canvas.width= window.innerWidth;
canvas.height=500;

var c=canvas.getContext('2d');

const mouse={
    x: undefined,
    y: undefined
}
const colorArray =[
    '#1C213F','#313A87','#F3B900','#F5534F'
];
window.addEventListener('mousemove',(event)=>{
    mouse.x = event.x;
    mouse.y = event.y;
})
window.addEventListener('resize',()=>{
    canvas.width= window.innerWidth;
    canvas.height= 500;
    init();
})

const maxRaduis = 40;
// const minRaduis = 3;

function Circle(x,y,dx,dy,raduis){
    this.x=x;
    this.y=y;
    this.dx=dx;
    this.dy=dy;
    this.raduis=raduis;
    this.minRaduis=raduis;
    this.color= colorArray[Math.floor(Math.random() * colorArray.length)];

    this.draw=function(){
        c.beginPath();
        c.arc(this.x, this.y, this.raduis, 0, Math.PI * 2, false);
        c.fillStyle = this.color;
        c.fill();
    }
    this.update=function(){
        if(this.x+this.raduis > innerWidth || this.x-this.raduis <0)
        this.dx=-this.dx;
        if(this.y+this.raduis > innerHeight || this.y-this.raduis <0)
        this.dy=-this.dy;
        this.x+=this.dx;
        this.y+=this.dy;

        //interaction
        if(mouse.x - this.x < 100 && mouse.x - this.x > -100
            && mouse.y - this.y <100 && mouse.y - this.y > -100){
            
            if( this.raduis < maxRaduis)
                this.raduis +=1;
                
        }else 
            if(this.raduis > this.minRaduis)
                this.raduis -= 1;

        this.draw();
    }
}
//macircle.draw();

var circleArray = [];
function init() {
    circleArray = [];
    for(var i=0;i<300;i++){
        var raduis=Math.random() * 6 + 1;
        var x=Math.random() * (innerWidth - raduis*2)+raduis;
        var y=Math.random() * (innerHeight - raduis*2)+raduis;
        var dx=(Math.random() - 1) * 2;
        var dy=(Math.random() - 1) * 2;
        
        circleArray.push(new Circle(x,y,dx,dy,raduis));
    }
    
}

function animate(){
    requestAnimationFrame(animate);
    c.clearRect(0,0,innerWidth,innerHeight);
    circleArray.forEach(element => {
        element.update();
    });
    
}

init();
animate();