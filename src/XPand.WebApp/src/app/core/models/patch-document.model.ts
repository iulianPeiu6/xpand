export type PatchDocument = PatchDocumentOperation[];

export interface PatchDocumentOperation {
  op: string;
  path: string;
  value: any;
}
