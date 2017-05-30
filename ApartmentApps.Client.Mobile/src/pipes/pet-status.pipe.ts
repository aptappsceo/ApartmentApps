import {PipeTransform, Pipe} from "@angular/core";


@Pipe({ name: 'petstatus', pure: true})
export class PetStatusPipe implements PipeTransform {
  transform(val : number) {
    if(val === 0 ){
      return 'No Pet';
    } else if(val === 1) {
      return 'Contained Pet'
    } else if(val === 2) {
      return 'Free Pet';
    } else {
      return '';
    }

  }
}
