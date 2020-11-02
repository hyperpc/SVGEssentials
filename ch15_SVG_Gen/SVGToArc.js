function svgToArc(x0,y0,rx,ry,xAngle,largeArcFlag,sweepFlag, x,y){
    var dx2=(x0-x)/2.0;
    var dy2=(y0-y)/2.0;

    xAngle = Math.PI*(xAngle%360.0)/180.0;
    var cosXAngle=Math.cos(xAngle);
    var sinXAngle=Math.sin(xAngle);

    var x1=(cosXAngle*dx2+sinXAngle*dy2);
    var y1=(-sinXAngle*dx2+cosXAngle*dy2);

    rx=Math.abs(rx);
    ry=Math.abs(ry);
    var rxSq=rx*rx;
    var rySq=ry*ry;
    var x1Sq=x1*x1;
    var y1Sq=y1*y1;

    var radiuCheck=x1Sq/rxSq+y1Sq/rySq;
    if(radiuCheck>1){
        rx=Math.sqrt(radiuCheck)*rx;
        ry=Math.sqrt(radiuCheck)*ry;
        rxSq=rx*rx;
        rySq=ry*ry;
    }

    var var sign=(largeArcFlag==sweepFlag)?1:0;
    var sq=((rxSq*rySq)-(rxSq*y1Sq)-(rySq*x1Sq))/((rxSq*y1Sq)+(rySq*x1Sq));
    sq=(sq<0)?0:sq;
    var coef=(sign*Math.sqrt(sq));
    var cx1=coef*((rx*y1)/ry);
    var cy1=coef*-((ry*x1)/rx);

    var sx2=(x0+x)/2.0;
    var sy2=(y0+y)/2.0;

    var cx=sx2+(cosXAngle*cx1-sinXAngle*cy1);
    var cy=sy2+(sinXAngle*cx1+cosXAngle*cy1);

    var ux=(x1-cx1)/rx;
    var uy=(y1-cy1)/ry;
    var vx=(-x1-cx1)/rx;
    var vy=(-y1-cy1)/ry;

    var p,n;
    n=Math.sqrt((ux*ux)+(uy*uy));
    p=ux; //(1*ux)+(0*uy)
    sign=(uy<0)?-1.0:1.0;
    var angleStart=180.0*(sign*Math.acos(p/n))/Math.PI;

    n=Math.sqrt((ux*ux+uy*uy)*(vx*vx+vy*vy));
    p=ux*vx+uy*vy;
    sign=(ux*vy-uy*vx<0)?-1.0:1.0;
    var angleExtend=180.0*(sign*Math.acos(p/n))/Math.PI;
    if(!sweepFlag&&angleExtend>0){
        angleExtend-=360.0;
    }else if(sweepFlag && angleExtend<0){
        angleExtend+=360.0;
    }
    angleExtend%=360;
    angleStart%=360;

    return ([cx,cy,rx,ry,angleStart, angleExtend,xAngle]);
}