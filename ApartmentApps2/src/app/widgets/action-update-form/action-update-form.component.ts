import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-action-update-form',
  templateUrl: './action-update-form.component.html',
  styleUrls: ['./action-update-form.component.css']
})
export class ActionUpdateFormComponent implements OnInit {
  schema: any;
  model: any = { comments: 'yup' };
  constructor() {
    this.schema = {
        'properties': {
          'comments': {
            'type': 'string',
            'description': 'Comments'
          }
        }
    };
   }

  ngOnInit() {
  }

}
