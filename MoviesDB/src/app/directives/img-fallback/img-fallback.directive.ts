import { Directive, Input, ElementRef, HostListener } from '@angular/core';

@Directive({
  selector: 'img[appImgFallback]'
})
export class ImgFallbackDirective {

  @Input() appImgFallback: string;

  constructor(
    private elementRef: ElementRef
  ) { }

  @HostListener('error')
  loadFallbackImageOnError(){
    const element: HTMLImageElement = <HTMLImageElement>this.elementRef.nativeElement;
    element.src = this.appImgFallback || 'assets/no-poster.jpg';
  }

}
