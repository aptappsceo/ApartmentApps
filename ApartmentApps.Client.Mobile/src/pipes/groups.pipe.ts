import { Pipe, PipeTransform } from '@angular/core';
import * as _ from 'lodash';
@Pipe({ name: 'groups', pure: true})
export class GroupsPipe implements PipeTransform {
  transform(val:any[], cols:number) {
    return _.chain(val || []).chunk(cols || 3).value();
  }
}

