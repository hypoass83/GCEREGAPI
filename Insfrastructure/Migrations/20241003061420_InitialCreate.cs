using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Insfrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Archives",
                columns: table => new
                {
                    ArchiveID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileBase64 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContentType = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Archives", x => x.ArchiveID);
                });

            migrationBuilder.CreateTable(
                name: "BannedCandidates",
                columns: table => new
                {
                    BannedCandidateID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BannedSession = table.Column<int>(type: "int", nullable: false),
                    BannedExamCode = table.Column<int>(type: "int", nullable: false),
                    BannedCandNumber = table.Column<long>(type: "bigint", nullable: false),
                    MinesecMatricule = table.Column<long>(type: "bigint", nullable: false),
                    CandName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Duration = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BannedCandidates", x => x.BannedCandidateID);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    CountryID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CountryCode = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    CountryName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.CountryID);
                });

            migrationBuilder.CreateTable(
                name: "Exams",
                columns: table => new
                {
                    ExamID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExamCode = table.Column<int>(type: "int", nullable: false),
                    ExamName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RegFee = table.Column<double>(type: "float", nullable: false),
                    LateEntryFee = table.Column<double>(type: "float", nullable: false),
                    MinRegSub = table.Column<int>(type: "int", nullable: false),
                    MaxRegSub = table.Column<int>(type: "int", nullable: false),
                    ExamType = table.Column<int>(type: "int", nullable: false),
                    SubjectFee = table.Column<double>(type: "float", nullable: false),
                    PracticalFee = table.Column<double>(type: "float", nullable: false),
                    CandNumSeed = table.Column<int>(type: "int", nullable: false),
                    RequiredMax = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    ReqSpec = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exams", x => x.ExamID);
                });

            migrationBuilder.CreateTable(
                name: "ImpairmentDegrees",
                columns: table => new
                {
                    ImpairmentDegreeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DegreeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DegreeDesc = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImpairmentDegrees", x => x.ImpairmentDegreeID);
                });

            migrationBuilder.CreateTable(
                name: "Impairments",
                columns: table => new
                {
                    ImpairmentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImpairmentType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImpairmentDesc = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Impairments", x => x.ImpairmentID);
                });

            migrationBuilder.CreateTable(
                name: "IndexCats",
                columns: table => new
                {
                    IndexCatID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IndexCatCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IndexCatName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IndexCats", x => x.IndexCatID);
                });

            migrationBuilder.CreateTable(
                name: "Jobs",
                columns: table => new
                {
                    JobID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JobCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    JobLabel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JobDescription = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jobs", x => x.JobID);
                });

            migrationBuilder.CreateTable(
                name: "Modules",
                columns: table => new
                {
                    ModuleID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModuleCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModuleLabel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModuleDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModuleImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModuleArea = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModuleState = table.Column<bool>(type: "bit", nullable: false),
                    AppearanceOrder = table.Column<int>(type: "int", nullable: false),
                    ModuleStatus = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Modules", x => x.ModuleID);
                });

            migrationBuilder.CreateTable(
                name: "Profiles",
                columns: table => new
                {
                    ProfileID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProfileCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProfileLabel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProfileDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProfileState = table.Column<bool>(type: "bit", nullable: false),
                    ProfileLevel = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profiles", x => x.ProfileID);
                });

            migrationBuilder.CreateTable(
                name: "Qualifications",
                columns: table => new
                {
                    QualificationID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QualificationCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QualificationName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Qualifications", x => x.QualificationID);
                });

            migrationBuilder.CreateTable(
                name: "Ranks",
                columns: table => new
                {
                    RankID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RankCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RankName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ranks", x => x.RankID);
                });

            migrationBuilder.CreateTable(
                name: "SelectedExaminers",
                columns: table => new
                {
                    SelectedExaminerID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoeCode = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    NameofExaminer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Post = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Institution = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Qualif = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IndexCat = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Division = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubjectCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExamCode = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SelectedExaminers", x => x.SelectedExaminerID);
                });

            migrationBuilder.CreateTable(
                name: "Sexes",
                columns: table => new
                {
                    SexID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SexLabel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SexCode = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sexes", x => x.SexID);
                });

            migrationBuilder.CreateTable(
                name: "Specialies",
                columns: table => new
                {
                    SpecialtyID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SpecialtyCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SpecialtyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShortName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SpecialtyType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specialies", x => x.SpecialtyID);
                });

            migrationBuilder.CreateTable(
                name: "SubjectGroups",
                columns: table => new
                {
                    SubjectGroupID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GroupNumber = table.Column<int>(type: "int", nullable: false),
                    GroupName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubjectGroups", x => x.SubjectGroupID);
                });

            migrationBuilder.CreateTable(
                name: "Subjects",
                columns: table => new
                {
                    SubjectID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubjectCode = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    SubjectName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SubjectTag = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: true),
                    NumPapers = table.Column<int>(type: "int", nullable: false),
                    HasPract = table.Column<bool>(type: "bit", nullable: false),
                    AltSubCode = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    MkSng = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subjects", x => x.SubjectID);
                });

            migrationBuilder.CreateTable(
                name: "Regions",
                columns: table => new
                {
                    RegionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RegionCode = table.Column<int>(type: "int", nullable: false),
                    RegionName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CountryID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Regions", x => x.RegionID);
                    table.ForeignKey(
                        name: "FK_Regions_Countries_CountryID",
                        column: x => x.CountryID,
                        principalTable: "Countries",
                        principalColumn: "CountryID");
                });

            migrationBuilder.CreateTable(
                name: "ImpairmentSupports",
                columns: table => new
                {
                    ImpairmentSupportID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SupportType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SupportDesc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImpairmentID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImpairmentSupports", x => x.ImpairmentSupportID);
                    table.ForeignKey(
                        name: "FK_ImpairmentSupports_Impairments_ImpairmentID",
                        column: x => x.ImpairmentID,
                        principalTable: "Impairments",
                        principalColumn: "ImpairmentID");
                });

            migrationBuilder.CreateTable(
                name: "Menus",
                columns: table => new
                {
                    MenuID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MenuCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MenuLabel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MenuDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MenuController = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MenuState = table.Column<bool>(type: "bit", nullable: false),
                    MenuFlat = table.Column<bool>(type: "bit", nullable: false),
                    MenuPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MenuIconName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsShortcut = table.Column<int>(type: "int", nullable: false),
                    ModuleID = table.Column<int>(type: "int", nullable: false),
                    AppearanceOrder = table.Column<int>(type: "int", nullable: false),
                    MenuStatus = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menus", x => x.MenuID);
                    table.ForeignKey(
                        name: "FK_Menus_Modules_ModuleID",
                        column: x => x.ModuleID,
                        principalTable: "Modules",
                        principalColumn: "ModuleID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SpecSubjects",
                columns: table => new
                {
                    SpecSubjectID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExamID = table.Column<int>(type: "int", nullable: false),
                    SpecialtyID = table.Column<int>(type: "int", nullable: false),
                    SubjectID = table.Column<int>(type: "int", nullable: false),
                    SubjectGroupID = table.Column<int>(type: "int", nullable: false),
                    Iscompulsory = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpecSubjects", x => x.SpecSubjectID);
                    table.ForeignKey(
                        name: "FK_SpecSubjects_Exams_ExamID",
                        column: x => x.ExamID,
                        principalTable: "Exams",
                        principalColumn: "ExamID");
                    table.ForeignKey(
                        name: "FK_SpecSubjects_Specialies_SpecialtyID",
                        column: x => x.SpecialtyID,
                        principalTable: "Specialies",
                        principalColumn: "SpecialtyID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SpecSubjects_SubjectGroups_SubjectGroupID",
                        column: x => x.SubjectGroupID,
                        principalTable: "SubjectGroups",
                        principalColumn: "SubjectGroupID");
                    table.ForeignKey(
                        name: "FK_SpecSubjects_Subjects_SubjectID",
                        column: x => x.SubjectID,
                        principalTable: "Subjects",
                        principalColumn: "SubjectID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TimeTables",
                columns: table => new
                {
                    TimeTableID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Session = table.Column<int>(type: "int", nullable: false),
                    ExamID = table.Column<int>(type: "int", nullable: false),
                    SubjectID = table.Column<int>(type: "int", nullable: false),
                    PaperNumber = table.Column<int>(type: "int", nullable: false),
                    ExamDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExamMoment = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    ExamHours = table.Column<int>(type: "int", nullable: true),
                    ExamMinutes = table.Column<int>(type: "int", nullable: true),
                    StartRmq = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TimeTables", x => x.TimeTableID);
                    table.ForeignKey(
                        name: "FK_TimeTables_Exams_ExamID",
                        column: x => x.ExamID,
                        principalTable: "Exams",
                        principalColumn: "ExamID");
                    table.ForeignKey(
                        name: "FK_TimeTables_Subjects_SubjectID",
                        column: x => x.SubjectID,
                        principalTable: "Subjects",
                        principalColumn: "SubjectID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Divisions",
                columns: table => new
                {
                    DivisionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DivisionCode = table.Column<int>(type: "int", nullable: false),
                    DivisionName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DivisionTag = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: true),
                    RegionID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Divisions", x => x.DivisionID);
                    table.ForeignKey(
                        name: "FK_Divisions_Regions_RegionID",
                        column: x => x.RegionID,
                        principalTable: "Regions",
                        principalColumn: "RegionID");
                });

            migrationBuilder.CreateTable(
                name: "ActionMenuProfiles",
                columns: table => new
                {
                    ActionMenuProfileID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Delete = table.Column<bool>(type: "bit", nullable: false),
                    Add = table.Column<bool>(type: "bit", nullable: false),
                    Update = table.Column<bool>(type: "bit", nullable: false),
                    MenuID = table.Column<int>(type: "int", nullable: false),
                    ProfileID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActionMenuProfiles", x => x.ActionMenuProfileID);
                    table.ForeignKey(
                        name: "FK_ActionMenuProfiles_Menus_MenuID",
                        column: x => x.MenuID,
                        principalTable: "Menus",
                        principalColumn: "MenuID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ActionMenuProfiles_Profiles_ProfileID",
                        column: x => x.ProfileID,
                        principalTable: "Profiles",
                        principalColumn: "ProfileID");
                });

            migrationBuilder.CreateTable(
                name: "SubMenus",
                columns: table => new
                {
                    SubMenuID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubMenuCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SubMenuLabel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubMenuDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubMenuController = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubMenuState = table.Column<bool>(type: "bit", nullable: false),
                    SubMenuPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubMenuIcon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsShortcut = table.Column<int>(type: "int", nullable: false),
                    MenuID = table.Column<int>(type: "int", nullable: false),
                    AppearanceOrder = table.Column<int>(type: "int", nullable: false),
                    SubMenuStatus = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubMenus", x => x.SubMenuID);
                    table.ForeignKey(
                        name: "FK_SubMenus_Menus_MenuID",
                        column: x => x.MenuID,
                        principalTable: "Menus",
                        principalColumn: "MenuID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SubDivisions",
                columns: table => new
                {
                    SubDivisionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubDivisionCode = table.Column<int>(type: "int", nullable: false),
                    SubDivisionName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DivisionID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubDivisions", x => x.SubDivisionID);
                    table.ForeignKey(
                        name: "FK_SubDivisions_Divisions_DivisionID",
                        column: x => x.DivisionID,
                        principalTable: "Divisions",
                        principalColumn: "DivisionID");
                });

            migrationBuilder.CreateTable(
                name: "ActionSubMenuProfiles",
                columns: table => new
                {
                    ActionSubMenuProfileID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Delete = table.Column<bool>(type: "bit", nullable: false),
                    Add = table.Column<bool>(type: "bit", nullable: false),
                    Update = table.Column<bool>(type: "bit", nullable: false),
                    SubMenuID = table.Column<int>(type: "int", nullable: false),
                    ProfileID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActionSubMenuProfiles", x => x.ActionSubMenuProfileID);
                    table.ForeignKey(
                        name: "FK_ActionSubMenuProfiles_Profiles_ProfileID",
                        column: x => x.ProfileID,
                        principalTable: "Profiles",
                        principalColumn: "ProfileID");
                    table.ForeignKey(
                        name: "FK_ActionSubMenuProfiles_SubMenus_SubMenuID",
                        column: x => x.SubMenuID,
                        principalTable: "SubMenus",
                        principalColumn: "SubMenuID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Adresses",
                columns: table => new
                {
                    AdressID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdressPhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AdressCellNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AdressFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AdressEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AdressWebSite = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AdressPOBox = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AdressFax = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SubDivisionID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adresses", x => x.AdressID);
                    table.ForeignKey(
                        name: "FK_Adresses_SubDivisions_SubDivisionID",
                        column: x => x.SubDivisionID,
                        principalTable: "SubDivisions",
                        principalColumn: "SubDivisionID");
                });

            migrationBuilder.CreateTable(
                name: "AcomCentres",
                columns: table => new
                {
                    AcomCentreID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AcomCentreCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AcomCentreName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AbbreviatedName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DivTag = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: true),
                    AdressID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AcomCentres", x => x.AcomCentreID);
                    table.ForeignKey(
                        name: "FK_AcomCentres_Adresses_AdressID",
                        column: x => x.AdressID,
                        principalTable: "Adresses",
                        principalColumn: "AdressID");
                });

            migrationBuilder.CreateTable(
                name: "GlobalPeople",
                columns: table => new
                {
                    GlobalPersonID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tiergroup = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CNI = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    AdressID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GlobalPeople", x => x.GlobalPersonID);
                    table.ForeignKey(
                        name: "FK_GlobalPeople_Adresses_AdressID",
                        column: x => x.AdressID,
                        principalTable: "Adresses",
                        principalColumn: "AdressID");
                });

            migrationBuilder.CreateTable(
                name: "People",
                columns: table => new
                {
                    GlobalPersonID = table.Column<int>(type: "int", nullable: false),
                    IsConnected = table.Column<bool>(type: "bit", nullable: false),
                    SexID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_People", x => x.GlobalPersonID);
                    table.ForeignKey(
                        name: "FK_People_GlobalPeople_GlobalPersonID",
                        column: x => x.GlobalPersonID,
                        principalTable: "GlobalPeople",
                        principalColumn: "GlobalPersonID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_People_Sexes_SexID",
                        column: x => x.SexID,
                        principalTable: "Sexes",
                        principalColumn: "SexID");
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    GlobalPersonID = table.Column<int>(type: "int", nullable: false),
                    UserLogin = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    UserPassword = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserAccessLevel = table.Column<int>(type: "int", nullable: false),
                    UserAccountState = table.Column<bool>(type: "bit", nullable: false),
                    JobID = table.Column<int>(type: "int", nullable: false),
                    ProfileID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.GlobalPersonID);
                    table.ForeignKey(
                        name: "FK_Users_Jobs_JobID",
                        column: x => x.JobID,
                        principalTable: "Jobs",
                        principalColumn: "JobID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Users_People_GlobalPersonID",
                        column: x => x.GlobalPersonID,
                        principalTable: "People",
                        principalColumn: "GlobalPersonID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Users_Profiles_ProfileID",
                        column: x => x.ProfileID,
                        principalTable: "Profiles",
                        principalColumn: "ProfileID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Examcentres",
                columns: table => new
                {
                    ExamCentreID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExamCentreCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExamCentreName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AbbreviatedName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CentreType = table.Column<int>(type: "int", nullable: false),
                    ExamType = table.Column<int>(type: "int", nullable: false),
                    SchoolNature = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsROEOnly = table.Column<bool>(type: "bit", nullable: false),
                    HostCentreCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AdressID = table.Column<int>(type: "int", nullable: false),
                    AcomCentreID = table.Column<int>(type: "int", nullable: true),
                    UserID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Examcentres", x => x.ExamCentreID);
                    table.ForeignKey(
                        name: "FK_Examcentres_AcomCentres_AcomCentreID",
                        column: x => x.AcomCentreID,
                        principalTable: "AcomCentres",
                        principalColumn: "AcomCentreID");
                    table.ForeignKey(
                        name: "FK_Examcentres_Adresses_AdressID",
                        column: x => x.AdressID,
                        principalTable: "Adresses",
                        principalColumn: "AdressID");
                    table.ForeignKey(
                        name: "FK_Examcentres_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "GlobalPersonID");
                });

            migrationBuilder.CreateTable(
                name: "Candidates",
                columns: table => new
                {
                    CandidateID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExamID = table.Column<int>(type: "int", nullable: false),
                    Session = table.Column<int>(type: "int", nullable: false),
                    ExamCentreID = table.Column<int>(type: "int", nullable: false),
                    CandNumber = table.Column<long>(type: "bigint", nullable: false),
                    MinesecMatricule = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CandName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sex = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    BirthDate = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    PlaceOfBirth = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    SubDivisionID = table.Column<int>(type: "int", nullable: true),
                    TelNo = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    SpecialtyID = table.Column<int>(type: "int", nullable: true),
                    SpecialtyNAID = table.Column<int>(type: "int", nullable: true),
                    Picture4x4Path = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ScanG3FormPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ScanBirthCertificatePath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ScanHighDiplomaPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ScanIDCardPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfCreation = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Candidates", x => x.CandidateID);
                    table.ForeignKey(
                        name: "FK_Candidates_Examcentres_ExamCentreID",
                        column: x => x.ExamCentreID,
                        principalTable: "Examcentres",
                        principalColumn: "ExamCentreID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Candidates_Exams_ExamID",
                        column: x => x.ExamID,
                        principalTable: "Exams",
                        principalColumn: "ExamID");
                    table.ForeignKey(
                        name: "FK_Candidates_Specialies_SpecialtyID",
                        column: x => x.SpecialtyID,
                        principalTable: "Specialies",
                        principalColumn: "SpecialtyID");
                    table.ForeignKey(
                        name: "FK_Candidates_Specialies_SpecialtyNAID",
                        column: x => x.SpecialtyNAID,
                        principalTable: "Specialies",
                        principalColumn: "SpecialtyID");
                    table.ForeignKey(
                        name: "FK_Candidates_SubDivisions_SubDivisionID",
                        column: x => x.SubDivisionID,
                        principalTable: "SubDivisions",
                        principalColumn: "SubDivisionID");
                });

            migrationBuilder.CreateTable(
                name: "Examiners",
                columns: table => new
                {
                    ExaminerID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Session = table.Column<int>(type: "int", nullable: false),
                    ROECODE = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    FullNames = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExamID = table.Column<int>(type: "int", nullable: false),
                    ExamCentreID = table.Column<int>(type: "int", nullable: false),
                    QualificationID = table.Column<int>(type: "int", nullable: false),
                    Specialisation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IndexCatID = table.Column<int>(type: "int", nullable: false),
                    SubjectID = table.Column<int>(type: "int", nullable: true),
                    SpecialtyID = table.Column<int>(type: "int", nullable: true),
                    ExaminerType = table.Column<int>(type: "int", nullable: false),
                    RankID = table.Column<int>(type: "int", nullable: true),
                    TeachExperience = table.Column<int>(type: "int", nullable: false),
                    MarkExperience = table.Column<int>(type: "int", nullable: false),
                    SubDivisionID = table.Column<int>(type: "int", nullable: false),
                    DateOfCreation = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Examiners", x => x.ExaminerID);
                    table.ForeignKey(
                        name: "FK_Examiners_Examcentres_ExamCentreID",
                        column: x => x.ExamCentreID,
                        principalTable: "Examcentres",
                        principalColumn: "ExamCentreID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Examiners_Exams_ExamID",
                        column: x => x.ExamID,
                        principalTable: "Exams",
                        principalColumn: "ExamID");
                    table.ForeignKey(
                        name: "FK_Examiners_IndexCats_IndexCatID",
                        column: x => x.IndexCatID,
                        principalTable: "IndexCats",
                        principalColumn: "IndexCatID");
                    table.ForeignKey(
                        name: "FK_Examiners_Qualifications_QualificationID",
                        column: x => x.QualificationID,
                        principalTable: "Qualifications",
                        principalColumn: "QualificationID");
                    table.ForeignKey(
                        name: "FK_Examiners_Ranks_RankID",
                        column: x => x.RankID,
                        principalTable: "Ranks",
                        principalColumn: "RankID");
                    table.ForeignKey(
                        name: "FK_Examiners_Specialies_SpecialtyID",
                        column: x => x.SpecialtyID,
                        principalTable: "Specialies",
                        principalColumn: "SpecialtyID");
                    table.ForeignKey(
                        name: "FK_Examiners_SubDivisions_SubDivisionID",
                        column: x => x.SubDivisionID,
                        principalTable: "SubDivisions",
                        principalColumn: "SubDivisionID");
                    table.ForeignKey(
                        name: "FK_Examiners_Subjects_SubjectID",
                        column: x => x.SubjectID,
                        principalTable: "Subjects",
                        principalColumn: "SubjectID");
                });

            migrationBuilder.CreateTable(
                name: "ExamSessions",
                columns: table => new
                {
                    ExamSessionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Session = table.Column<int>(type: "int", nullable: false),
                    SessionName = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    RegStart = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RegEnd = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RegClose = table.Column<bool>(type: "bit", nullable: false),
                    ExamCentreID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExamSessions", x => x.ExamSessionID);
                    table.ForeignKey(
                        name: "FK_ExamSessions_Examcentres_ExamCentreID",
                        column: x => x.ExamCentreID,
                        principalTable: "Examcentres",
                        principalColumn: "ExamCentreID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Mouchards",
                columns: table => new
                {
                    MouchardID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MoucharDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SneackHour = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserID = table.Column<int>(type: "int", nullable: true),
                    MoucharAction = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MoucharDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MoucharOperationType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MoucharProcedureName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MoucharHost = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MoucharHostAdress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExamcentreID = table.Column<int>(type: "int", nullable: true),
                    MoucharBusinessDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mouchards", x => x.MouchardID);
                    table.ForeignKey(
                        name: "FK_Mouchards_Examcentres_ExamcentreID",
                        column: x => x.ExamcentreID,
                        principalTable: "Examcentres",
                        principalColumn: "ExamCentreID");
                    table.ForeignKey(
                        name: "FK_Mouchards_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "GlobalPersonID");
                });

            migrationBuilder.CreateTable(
                name: "CandSubjects",
                columns: table => new
                {
                    CandSubjectID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Session = table.Column<int>(type: "int", nullable: false),
                    CandidateID = table.Column<int>(type: "int", nullable: false),
                    SubjectID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CandSubjects", x => x.CandSubjectID);
                    table.ForeignKey(
                        name: "FK_CandSubjects_Candidates_CandidateID",
                        column: x => x.CandidateID,
                        principalTable: "Candidates",
                        principalColumn: "CandidateID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CandSubjects_Subjects_SubjectID",
                        column: x => x.SubjectID,
                        principalTable: "Subjects",
                        principalColumn: "SubjectID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ImpairmentCandidates",
                columns: table => new
                {
                    ImpairmentCandidateID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Session = table.Column<int>(type: "int", nullable: false),
                    CandidateID = table.Column<int>(type: "int", nullable: false),
                    ImpairmentID = table.Column<int>(type: "int", nullable: true),
                    ImpairmentDegreeID = table.Column<int>(type: "int", nullable: true),
                    ImpairmentSupportID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImpairmentCandidates", x => x.ImpairmentCandidateID);
                    table.ForeignKey(
                        name: "FK_ImpairmentCandidates_Candidates_CandidateID",
                        column: x => x.CandidateID,
                        principalTable: "Candidates",
                        principalColumn: "CandidateID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ImpairmentCandidates_ImpairmentDegrees_ImpairmentDegreeID",
                        column: x => x.ImpairmentDegreeID,
                        principalTable: "ImpairmentDegrees",
                        principalColumn: "ImpairmentDegreeID");
                    table.ForeignKey(
                        name: "FK_ImpairmentCandidates_ImpairmentSupports_ImpairmentSupportID",
                        column: x => x.ImpairmentSupportID,
                        principalTable: "ImpairmentSupports",
                        principalColumn: "ImpairmentSupportID");
                    table.ForeignKey(
                        name: "FK_ImpairmentCandidates_Impairments_ImpairmentID",
                        column: x => x.ImpairmentID,
                        principalTable: "Impairments",
                        principalColumn: "ImpairmentID");
                });

            migrationBuilder.CreateTable(
                name: "ValidateRegistrations",
                columns: table => new
                {
                    ValidateRegistrationID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Session = table.Column<int>(type: "int", nullable: false),
                    CandidateID = table.Column<int>(type: "int", nullable: false),
                    PmtCode = table.Column<int>(type: "int", nullable: false),
                    AmtPaid = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ValidateRegistrations", x => x.ValidateRegistrationID);
                    table.ForeignKey(
                        name: "FK_ValidateRegistrations_Candidates_CandidateID",
                        column: x => x.CandidateID,
                        principalTable: "Candidates",
                        principalColumn: "CandidateID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AcomCentres_AdressID",
                table: "AcomCentres",
                column: "AdressID");

            migrationBuilder.CreateIndex(
                name: "IX_ActionMenuProfiles_MenuID",
                table: "ActionMenuProfiles",
                column: "MenuID");

            migrationBuilder.CreateIndex(
                name: "IX_ActionMenuProfiles_ProfileID",
                table: "ActionMenuProfiles",
                column: "ProfileID");

            migrationBuilder.CreateIndex(
                name: "IX_ActionSubMenuProfiles_ProfileID",
                table: "ActionSubMenuProfiles",
                column: "ProfileID");

            migrationBuilder.CreateIndex(
                name: "IX_ActionSubMenuProfiles_SubMenuID",
                table: "ActionSubMenuProfiles",
                column: "SubMenuID");

            migrationBuilder.CreateIndex(
                name: "IX_Adresses_SubDivisionID",
                table: "Adresses",
                column: "SubDivisionID");

            migrationBuilder.CreateIndex(
                name: "IX_Candidates_ExamCentreID",
                table: "Candidates",
                column: "ExamCentreID");

            migrationBuilder.CreateIndex(
                name: "IX_Candidates_ExamID",
                table: "Candidates",
                column: "ExamID");

            migrationBuilder.CreateIndex(
                name: "IX_Candidates_SpecialtyID",
                table: "Candidates",
                column: "SpecialtyID");

            migrationBuilder.CreateIndex(
                name: "IX_Candidates_SpecialtyNAID",
                table: "Candidates",
                column: "SpecialtyNAID");

            migrationBuilder.CreateIndex(
                name: "IX_Candidates_SubDivisionID",
                table: "Candidates",
                column: "SubDivisionID");

            migrationBuilder.CreateIndex(
                name: "IX_CandSubjects_CandidateID",
                table: "CandSubjects",
                column: "CandidateID");

            migrationBuilder.CreateIndex(
                name: "IX_CandSubjects_SubjectID",
                table: "CandSubjects",
                column: "SubjectID");

            migrationBuilder.CreateIndex(
                name: "IX_Divisions_RegionID",
                table: "Divisions",
                column: "RegionID");

            migrationBuilder.CreateIndex(
                name: "IX_Examcentres_AcomCentreID",
                table: "Examcentres",
                column: "AcomCentreID");

            migrationBuilder.CreateIndex(
                name: "IX_Examcentres_AdressID",
                table: "Examcentres",
                column: "AdressID");

            migrationBuilder.CreateIndex(
                name: "IX_Examcentres_UserID",
                table: "Examcentres",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Examiners_ExamCentreID",
                table: "Examiners",
                column: "ExamCentreID");

            migrationBuilder.CreateIndex(
                name: "IX_Examiners_ExamID",
                table: "Examiners",
                column: "ExamID");

            migrationBuilder.CreateIndex(
                name: "IX_Examiners_IndexCatID",
                table: "Examiners",
                column: "IndexCatID");

            migrationBuilder.CreateIndex(
                name: "IX_Examiners_QualificationID",
                table: "Examiners",
                column: "QualificationID");

            migrationBuilder.CreateIndex(
                name: "IX_Examiners_RankID",
                table: "Examiners",
                column: "RankID");

            migrationBuilder.CreateIndex(
                name: "IX_Examiners_SpecialtyID",
                table: "Examiners",
                column: "SpecialtyID");

            migrationBuilder.CreateIndex(
                name: "IX_Examiners_SubDivisionID",
                table: "Examiners",
                column: "SubDivisionID");

            migrationBuilder.CreateIndex(
                name: "IX_Examiners_SubjectID",
                table: "Examiners",
                column: "SubjectID");

            migrationBuilder.CreateIndex(
                name: "IX_ExamSessions_ExamCentreID",
                table: "ExamSessions",
                column: "ExamCentreID");

            migrationBuilder.CreateIndex(
                name: "IX_GlobalPeople_AdressID",
                table: "GlobalPeople",
                column: "AdressID");

            migrationBuilder.CreateIndex(
                name: "IX_ImpairmentCandidates_CandidateID",
                table: "ImpairmentCandidates",
                column: "CandidateID");

            migrationBuilder.CreateIndex(
                name: "IX_ImpairmentCandidates_ImpairmentDegreeID",
                table: "ImpairmentCandidates",
                column: "ImpairmentDegreeID");

            migrationBuilder.CreateIndex(
                name: "IX_ImpairmentCandidates_ImpairmentID",
                table: "ImpairmentCandidates",
                column: "ImpairmentID");

            migrationBuilder.CreateIndex(
                name: "IX_ImpairmentCandidates_ImpairmentSupportID",
                table: "ImpairmentCandidates",
                column: "ImpairmentSupportID");

            migrationBuilder.CreateIndex(
                name: "IX_ImpairmentSupports_ImpairmentID",
                table: "ImpairmentSupports",
                column: "ImpairmentID");

            migrationBuilder.CreateIndex(
                name: "IX_Menus_ModuleID",
                table: "Menus",
                column: "ModuleID");

            migrationBuilder.CreateIndex(
                name: "IX_Mouchards_ExamcentreID",
                table: "Mouchards",
                column: "ExamcentreID");

            migrationBuilder.CreateIndex(
                name: "IX_Mouchards_UserID",
                table: "Mouchards",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_People_SexID",
                table: "People",
                column: "SexID");

            migrationBuilder.CreateIndex(
                name: "IX_Regions_CountryID",
                table: "Regions",
                column: "CountryID");

            migrationBuilder.CreateIndex(
                name: "IX_SpecSubjects_ExamID",
                table: "SpecSubjects",
                column: "ExamID");

            migrationBuilder.CreateIndex(
                name: "IX_SpecSubjects_SpecialtyID",
                table: "SpecSubjects",
                column: "SpecialtyID");

            migrationBuilder.CreateIndex(
                name: "IX_SpecSubjects_SubjectGroupID",
                table: "SpecSubjects",
                column: "SubjectGroupID");

            migrationBuilder.CreateIndex(
                name: "IX_SpecSubjects_SubjectID",
                table: "SpecSubjects",
                column: "SubjectID");

            migrationBuilder.CreateIndex(
                name: "IX_SubDivisions_DivisionID",
                table: "SubDivisions",
                column: "DivisionID");

            migrationBuilder.CreateIndex(
                name: "IX_SubMenus_MenuID",
                table: "SubMenus",
                column: "MenuID");

            migrationBuilder.CreateIndex(
                name: "IX_TimeTables_ExamID",
                table: "TimeTables",
                column: "ExamID");

            migrationBuilder.CreateIndex(
                name: "IX_TimeTables_SubjectID",
                table: "TimeTables",
                column: "SubjectID");

            migrationBuilder.CreateIndex(
                name: "IX_Users_JobID",
                table: "Users",
                column: "JobID");

            migrationBuilder.CreateIndex(
                name: "IX_Users_ProfileID",
                table: "Users",
                column: "ProfileID");

            migrationBuilder.CreateIndex(
                name: "IX_ValidateRegistrations_CandidateID",
                table: "ValidateRegistrations",
                column: "CandidateID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActionMenuProfiles");

            migrationBuilder.DropTable(
                name: "ActionSubMenuProfiles");

            migrationBuilder.DropTable(
                name: "Archives");

            migrationBuilder.DropTable(
                name: "BannedCandidates");

            migrationBuilder.DropTable(
                name: "CandSubjects");

            migrationBuilder.DropTable(
                name: "Examiners");

            migrationBuilder.DropTable(
                name: "ExamSessions");

            migrationBuilder.DropTable(
                name: "ImpairmentCandidates");

            migrationBuilder.DropTable(
                name: "Mouchards");

            migrationBuilder.DropTable(
                name: "SelectedExaminers");

            migrationBuilder.DropTable(
                name: "SpecSubjects");

            migrationBuilder.DropTable(
                name: "TimeTables");

            migrationBuilder.DropTable(
                name: "ValidateRegistrations");

            migrationBuilder.DropTable(
                name: "SubMenus");

            migrationBuilder.DropTable(
                name: "IndexCats");

            migrationBuilder.DropTable(
                name: "Qualifications");

            migrationBuilder.DropTable(
                name: "Ranks");

            migrationBuilder.DropTable(
                name: "ImpairmentDegrees");

            migrationBuilder.DropTable(
                name: "ImpairmentSupports");

            migrationBuilder.DropTable(
                name: "SubjectGroups");

            migrationBuilder.DropTable(
                name: "Subjects");

            migrationBuilder.DropTable(
                name: "Candidates");

            migrationBuilder.DropTable(
                name: "Menus");

            migrationBuilder.DropTable(
                name: "Impairments");

            migrationBuilder.DropTable(
                name: "Examcentres");

            migrationBuilder.DropTable(
                name: "Exams");

            migrationBuilder.DropTable(
                name: "Specialies");

            migrationBuilder.DropTable(
                name: "Modules");

            migrationBuilder.DropTable(
                name: "AcomCentres");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Jobs");

            migrationBuilder.DropTable(
                name: "People");

            migrationBuilder.DropTable(
                name: "Profiles");

            migrationBuilder.DropTable(
                name: "GlobalPeople");

            migrationBuilder.DropTable(
                name: "Sexes");

            migrationBuilder.DropTable(
                name: "Adresses");

            migrationBuilder.DropTable(
                name: "SubDivisions");

            migrationBuilder.DropTable(
                name: "Divisions");

            migrationBuilder.DropTable(
                name: "Regions");

            migrationBuilder.DropTable(
                name: "Countries");
        }
    }
}
