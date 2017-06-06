import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-incident-report-form',
  templateUrl: './incident-report-form.component.html',
  styleUrls: ['./incident-report-form.component.css']
})
export class IncidentReportFormComponent implements OnInit {
  mySchema = {
    'properties': {
      'email': {
        'type': 'string',
        'description': 'email',
        'format': 'email'
      },
      'password': {
        'type': 'string',
        'description': 'Password'
      },
      'rememberMe': {
        'type': 'boolean',
        'default': false,
        'description': 'Remember me'
      }
    },
    'required': ['email','password','rememberMe']
  };
  myModel = {email: 'john.doe@example.com'};

  constructor() { }

  ngOnInit() {
  }

}
