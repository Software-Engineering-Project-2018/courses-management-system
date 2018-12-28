import { BaseObject } from './base-object';
import { DocumentObject } from './document-detail-object';
import { TaskDetailObject } from './task-detail-object';
import { TaskObject } from './task-object';

export class CourseObject extends BaseObject {

    CourseId: number;
    CourseName: string;
    DateStart: Date;
    DateEnd: Date;
    Tutition: number;
    CourseIntro: string;
    CourseLinkRef: string;
    DocumentDetailList: DocumentObject[];
    TaskList: TaskObject[];
    public constructor() {
        super();
        this.DocumentDetailList = [];
        this.TaskList = [];
    }
}
