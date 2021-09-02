import { StudentManagerServiceProxy } from './../../../shared/service-proxies/service-proxies';

import {
  Component,
  Injector,
  OnInit,
  EventEmitter,
  Output
} from '@angular/core';
import { BsModalRef } from 'ngx-bootstrap/modal';
import { forEach as _forEach, map as _map } from 'lodash-es';
import { AppComponentBase } from '@shared/app-component-base';
import {
  StudentDto
} from '@shared/service-proxies/service-proxies';
import * as moment from 'moment';

@Component({
  selector: 'app-createStudentDialog',
  templateUrl: './createStudentDialog.component.html',
  styleUrls: ['./createStudentDialog.component.css']
})
export class CreateStudentDialogComponent extends AppComponentBase implements OnInit {
  saving = false;
  student = new StudentDto();
  
  @Output() onSave = new EventEmitter<any>();

  constructor(
    injector: Injector,
    public _studentService: StudentManagerServiceProxy,
    public bsModalRef: BsModalRef
  ) {
    super(injector);
    
  }

  ngOnInit(): void {
    
  }

  

  save(): void {
    this.saving = true;
    this._studentService.studentCreator(this.student).subscribe(
      () => {
        this.notify.info(this.l('SavedSuccessfully'));
        this.bsModalRef.hide();
        this.onSave.emit();
      },
      () => {
        this.saving = false;
      }
    );
  }
  
}

