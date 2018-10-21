

public enum subFolders
{
    SchemaFileSource = 1,
    SchemaFileModifiedByPS = 2,

    DataFileSource = 11,
    DataFileByViews = 13,
    DataFileByCopyTool = 14,


    TargetBackUp = 21,

    ExportPackageZip = 31,
    ImportPackageZipByViews = 32,
    ImportPackageZipByCopyToolFromOrigin = 33,
    ImportPackageZipByCopyToolFromViews = 34,


    ContentTypeSource = 41,

    Logs = 51,
    TempFolder = 52
}

public enum fileName
{
    pathToFolderFromProjectRoot,
    appendFolderNameNoExt,
    appendFolderNameDotXml,
    appendFolderNameDotZip,
    appendfolderNameDotPSscript,
    dataFileXml,
    dataSchemaXml,
    contentTypesXml,
    log
}

public enum relationShipType
{
   Lookup = 1,
   Child = 2
}



