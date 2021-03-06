USE [ApartmentApps_Development]
GO
SET IDENTITY_INSERT [dbo].[ServiceQueries] ON 

GO
INSERT [dbo].[ServiceQueries] ([Id], [Name], [QueryJson], [Service], [QueryId], [PropertyId], [Index]) VALUES (1, N'Scheduled', N'<Query id="c297e01f-20d4-4ba4-a2dd-9379413dd5cc" name="Scheduled">
  <Description />
  <Columns />
  <JustSortedColumns />
  <Conditions linking="All">
    <Condition class="SMPL" enabled="True" readOnly="False">
      <Operator id="StartsWith" />
      <Expressions>
        <Expr class="ENTATTR" id="MaitenanceRequest.StatusId" />
        <Expr class="CONST" type="String" kind="Scalar" value="Scheduled" text="Scheduled" />
      </Expressions>
    </Condition>
  </Conditions>
</Query>', N'MaintenanceService', N'c297e01f-20d4-4ba4-a2dd-9379413dd5cc', 3, 0)
GO
INSERT [dbo].[ServiceQueries] ([Id], [Name], [QueryJson], [Service], [QueryId], [PropertyId], [Index]) VALUES (3, N'Reported', N'<Query id="466f82b7-619e-4012-815d-f78820f9bd53" name="Reported">
  <Description />
  <Columns />
  <JustSortedColumns />
  <Conditions linking="All">
    <Condition class="SMPL" enabled="True" readOnly="False">
      <Operator id="Equal" />
      <Expressions>
        <Expr class="ENTATTR" id="IncidentReport.StatusId" />
        <Expr class="CONST" type="String" kind="Scalar" value="Reported" text="Reported" />
      </Expressions>
    </Condition>
    <Condition class="SMPL" enabled="True" readOnly="False">
      <Operator id="DateWithinThisMonth" />
      <Expressions>
        <Expr class="ENTATTR" id="IncidentReport.CreatedOn" />
      </Expressions>
    </Condition>
  </Conditions>
</Query>', N'IncidentsService', N'466f82b7-619e-4012-815d-f78820f9bd53', 3, 0)
GO
INSERT [dbo].[ServiceQueries] ([Id], [Name], [QueryJson], [Service], [QueryId], [PropertyId], [Index]) VALUES (4, N'Open', N'<Query id="107535cf-c1a1-4071-9f5b-d280eef1209a" name="Open">
  <Description />
  <Columns />
  <JustSortedColumns />
  <Conditions linking="All">
    <Condition class="SMPL" enabled="True" readOnly="False">
      <Operator id="Equal" />
      <Expressions>
        <Expr class="ENTATTR" id="IncidentReport.StatusId" />
        <Expr class="CONST" type="String" kind="Scalar" value="Open" text="Open" />
      </Expressions>
    </Condition>
  </Conditions>
</Query>', N'IncidentsService', N'107535cf-c1a1-4071-9f5b-d280eef1209a', 3, 0)
GO
INSERT [dbo].[ServiceQueries] ([Id], [Name], [QueryJson], [Service], [QueryId], [PropertyId], [Index]) VALUES (5, N'Paused', N'<Query id="7e3f10e0-4738-4cf4-90b1-0fbc3410de3c" name="Paused">
  <Description />
  <Columns />
  <JustSortedColumns />
  <Conditions linking="All">
    <Condition class="SMPL" enabled="True" readOnly="False">
      <Operator id="StartsWith" />
      <Expressions>
        <Expr class="ENTATTR" id="IncidentReport.StatusId" />
        <Expr class="CONST" type="String" kind="Scalar" value="Paused" text="Paused" />
      </Expressions>
    </Condition>
  </Conditions>
</Query>', N'IncidentsService', N'7e3f10e0-4738-4cf4-90b1-0fbc3410de3c', 3, 0)
GO
INSERT [dbo].[ServiceQueries] ([Id], [Name], [QueryJson], [Service], [QueryId], [PropertyId], [Index]) VALUES (6, N'Complete', N'<Query id="0664762c-d36d-474e-b001-8972c9f59cce" name="Complete">
  <Description />
  <Columns />
  <JustSortedColumns />
  <Conditions linking="All">
    <Condition class="SMPL" enabled="True" readOnly="False">
      <Operator id="DateWithinThisMonth" />
      <Expressions>
        <Expr class="ENTATTR" id="IncidentReport.CompletionDate" />
      </Expressions>
    </Condition>
    <Condition class="SMPL" enabled="True" readOnly="False">
      <Operator id="Equal" />
      <Expressions>
        <Expr class="ENTATTR" id="IncidentReport.StatusId" />
        <Expr class="CONST" type="String" kind="Scalar" value="Complete" text="Complete" />
      </Expressions>
    </Condition>
  </Conditions>
</Query>', N'IncidentsService', N'0664762c-d36d-474e-b001-8972c9f59cce', 3, 0)
GO
INSERT [dbo].[ServiceQueries] ([Id], [Name], [QueryJson], [Service], [QueryId], [PropertyId], [Index]) VALUES (7, N'Active', N'<Query id="bfa33f80-9c99-4da8-8e83-088e8213393a" name="Active">
  <Description />
  <Columns />
  <JustSortedColumns />
  <Conditions linking="All" />
</Query>', N'UserService', N'bfa33f80-9c99-4da8-8e83-088e8213393a', 3, 0)
GO
INSERT [dbo].[ServiceQueries] ([Id], [Name], [QueryJson], [Service], [QueryId], [PropertyId], [Index]) VALUES (8, N'Inactive', N'<Query id="a53ca8d1-6b43-4e57-a652-8129d031b416" name="Inactive">
  <Description />
  <Columns />
  <JustSortedColumns />
  <Conditions linking="All">
    <Condition class="SMPL" enabled="True" readOnly="False">
      <Operator id="IsTrue" />
      <Expressions>
        <Expr class="ENTATTR" id="ApplicationUser.Archived" />
      </Expressions>
    </Condition>
  </Conditions>
</Query>', N'UserService', N'a53ca8d1-6b43-4e57-a652-8129d031b416', 3, 0)
GO
INSERT [dbo].[ServiceQueries] ([Id], [Name], [QueryJson], [Service], [QueryId], [PropertyId], [Index]) VALUES (9, N'Submitted', N'<Query id="40837d59-ac2a-4974-9045-9c063e08b77e" name="Submitted">
  <Description />
  <Columns />
  <JustSortedColumns />
  <Conditions linking="All">
    <Condition class="SMPL" enabled="True" readOnly="False">
      <Operator id="Equal" />
      <Expressions>
        <Expr class="ENTATTR" id="MaitenanceRequest.StatusId" />
        <Expr class="CONST" type="String" kind="Scalar" value="Submitted" text="Submitted" />
      </Expressions>
    </Condition>
  </Conditions>
</Query>', N'MaintenanceService', N'40837d59-ac2a-4974-9045-9c063e08b77e', 3, 0)
GO
INSERT [dbo].[ServiceQueries] ([Id], [Name], [QueryJson], [Service], [QueryId], [PropertyId], [Index]) VALUES (10, N'Started', N'<Query id="4db9e4ff-d853-41fc-8983-4cec34d7f855" name="Started">
  <Description />
  <Columns />
  <JustSortedColumns />
  <Conditions linking="All">
    <Condition class="SMPL" enabled="True" readOnly="False">
      <Operator id="Equal" />
      <Expressions>
        <Expr class="ENTATTR" id="MaitenanceRequest.StatusId" />
        <Expr class="CONST" type="String" kind="Scalar" value="Started" text="Started" />
      </Expressions>
    </Condition>
  </Conditions>
</Query>', N'MaintenanceService', N'4db9e4ff-d853-41fc-8983-4cec34d7f855', 3, 0)
GO
INSERT [dbo].[ServiceQueries] ([Id], [Name], [QueryJson], [Service], [QueryId], [PropertyId], [Index]) VALUES (11, N'Paused', N'<Query id="c12e04ba-0190-46c2-a946-fe2f49f209a0" name="Paused">
  <Description />
  <Columns />
  <JustSortedColumns />
  <Conditions linking="All">
    <Condition class="SMPL" enabled="True" readOnly="False">
      <Operator id="Equal" />
      <Expressions>
        <Expr class="ENTATTR" id="MaitenanceRequest.StatusId" />
        <Expr class="CONST" type="String" kind="Scalar" value="Paused" text="Paused" />
      </Expressions>
    </Condition>
  </Conditions>
</Query>', N'MaintenanceService', N'c12e04ba-0190-46c2-a946-fe2f49f209a0', 3, 0)
GO
INSERT [dbo].[ServiceQueries] ([Id], [Name], [QueryJson], [Service], [QueryId], [PropertyId], [Index]) VALUES (12, N'Complete', N'<Query id="a4271e74-7967-487b-8e59-570a993db571" name="Complete">
  <Description />
  <Columns />
  <JustSortedColumns />
  <Conditions linking="All">
    <Condition class="SMPL" enabled="True" readOnly="False">
      <Operator id="Equal" />
      <Expressions>
        <Expr class="ENTATTR" id="MaitenanceRequest.StatusId" />
        <Expr class="CONST" type="String" kind="Scalar" value="Complete" text="Complete" />
      </Expressions>
    </Condition>
    <Condition class="SMPL" enabled="True" readOnly="False">
      <Operator id="DateWithinThisMonth" />
      <Expressions>
        <Expr class="ENTATTR" id="MaitenanceRequest.CompletionDate" />
      </Expressions>
    </Condition>
  </Conditions>
</Query>', N'MaintenanceService', N'a4271e74-7967-487b-8e59-570a993db571', 3, 0)
GO
SET IDENTITY_INSERT [dbo].[ServiceQueries] OFF
GO
