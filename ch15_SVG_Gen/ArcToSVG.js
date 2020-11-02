function centeredToSVG(cx,cy,rx,ry,theta,delta,phi){
    var endTheta, phiRad;
    var x0,y0,x1,y1,largeArc,sweep;

    theta=theta*Math.PI/180.0;
    endTheta=(theta+delta)*Math.PI/180.0;
    phiRad=phi*Math.PI/180.0;

    x0=cx+Math.cos(phiRad)*rx*Math.cos(theta)+Math.sin(-phiRad)*ry*Math.sin(theta);
    
    y0=cx+Math.cos(phiRad)*ry*Math.cos(theta)+Math.sin(phiRad)*ry*Math.sin(theta);
    
    x1=cx+Math.cos(phiRad)*rx*Math.cos(endTheta)+Math.sin(-phiRad)*ry*Math.sin(endTheta);
    
    y1=cx+Math.cos(phiRad)*ry*Math.cos(endTheta)+Math.sin(phiRad)*ry*Math.sin(endTheta);
    
    largeArc=(delta>180)?1:0;
    sweep=(delta>0)?1:0;

    return [x0,y0, rx, ry, phi, largeArc, sweep, x1, y1];
}