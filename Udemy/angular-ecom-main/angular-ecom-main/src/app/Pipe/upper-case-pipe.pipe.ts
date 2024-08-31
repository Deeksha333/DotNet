import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'upperCasePipe'
})
export class UpperCasePipePipe implements PipeTransform {
  nvalue:string="";

  transform(value: any, ...args: any[]): any {
    this.nvalue = value.split('').reverse().join('');
    return this.nvalue;
  }

}
