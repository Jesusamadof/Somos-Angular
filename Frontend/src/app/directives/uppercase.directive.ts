import { Directive, ElementRef, HostListener } from '@angular/core';

@Directive({
  selector: '[appUppercase]'
})
export class UppercaseDirective {


  constructor(private el: ElementRef) { }

  @HostListener('input', ['$event']) onInput(event: Event) {
    const value = (event.target as HTMLInputElement).value;
    this.el.nativeElement.value = value.toUpperCase();
  }

}
