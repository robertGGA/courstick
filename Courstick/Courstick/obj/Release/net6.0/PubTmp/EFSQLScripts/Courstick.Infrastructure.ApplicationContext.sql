﻿CREATE TABLE IF NOT EXISTS "__EFMigrationsHistory" (
    "MigrationId" character varying(150) NOT NULL,
    "ProductVersion" character varying(32) NOT NULL,
    CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY ("MigrationId")
);

START TRANSACTION;


DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20220418122152_Init') THEN
    CREATE TABLE "AspNetRoles" (
        "Id" integer GENERATED BY DEFAULT AS IDENTITY,
        "RoleId" integer NOT NULL,
        "Name" character varying(256) NOT NULL,
        "NormalizedName" character varying(256) NULL,
        "ConcurrencyStamp" text NULL,
        CONSTRAINT "PK_AspNetRoles" PRIMARY KEY ("Id")
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20220418122152_Init') THEN
    CREATE TABLE "Statuses" (
        "StatusId" integer GENERATED BY DEFAULT AS IDENTITY,
        "StatusName" text NOT NULL,
        CONSTRAINT "PK_Statuses" PRIMARY KEY ("StatusId")
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20220418122152_Init') THEN
    CREATE TABLE "SubTypes" (
        "SubTypeId" integer GENERATED BY DEFAULT AS IDENTITY,
        "Criterion" text NOT NULL,
        CONSTRAINT "PK_SubTypes" PRIMARY KEY ("SubTypeId")
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20220418122152_Init') THEN
    CREATE TABLE "AspNetRoleClaims" (
        "Id" integer GENERATED BY DEFAULT AS IDENTITY,
        "RoleId" integer NOT NULL,
        "ClaimType" text NULL,
        "ClaimValue" text NULL,
        CONSTRAINT "PK_AspNetRoleClaims" PRIMARY KEY ("Id"),
        CONSTRAINT "FK_AspNetRoleClaims_AspNetRoles_RoleId" FOREIGN KEY ("RoleId") REFERENCES "AspNetRoles" ("Id") ON DELETE CASCADE
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20220418122152_Init') THEN
    CREATE TABLE "AspNetUsers" (
        "Id" integer GENERATED BY DEFAULT AS IDENTITY,
        "Name" text NULL,
        "Surname" text NULL,
        "Avatar" bytea NULL,
        "UserRoleId" integer NOT NULL,
        "UserName" character varying(256) NULL,
        "NormalizedUserName" character varying(256) NULL,
        "Email" character varying(256) NULL,
        "NormalizedEmail" character varying(256) NULL,
        "EmailConfirmed" boolean NOT NULL,
        "PasswordHash" text NULL,
        "SecurityStamp" text NULL,
        "ConcurrencyStamp" text NULL,
        "PhoneNumber" text NULL,
        "PhoneNumberConfirmed" boolean NOT NULL,
        "TwoFactorEnabled" boolean NOT NULL,
        "LockoutEnd" timestamp with time zone NULL,
        "LockoutEnabled" boolean NOT NULL,
        "AccessFailedCount" integer NOT NULL,
        CONSTRAINT "PK_AspNetUsers" PRIMARY KEY ("Id"),
        CONSTRAINT "FK_AspNetUsers_AspNetRoles_UserRoleId" FOREIGN KEY ("UserRoleId") REFERENCES "AspNetRoles" ("Id") ON DELETE CASCADE
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20220418122152_Init') THEN
    CREATE TABLE "Courses" (
        "CourseId" integer GENERATED BY DEFAULT AS IDENTITY,
        "Name" text NOT NULL,
        "SmallDescription" text NOT NULL,
        "Description" text NOT NULL,
        "Rating" double precision NOT NULL,
        "Price" double precision NOT NULL,
        "Image" bytea NOT NULL,
        "Passing_Time" time without time zone NOT NULL,
        "StatusId" integer NOT NULL,
        "SubTypeId" integer NULL,
        CONSTRAINT "PK_Courses" PRIMARY KEY ("CourseId"),
        CONSTRAINT "FK_Courses_Statuses_StatusId" FOREIGN KEY ("StatusId") REFERENCES "Statuses" ("StatusId") ON DELETE CASCADE,
        CONSTRAINT "FK_Courses_SubTypes_SubTypeId" FOREIGN KEY ("SubTypeId") REFERENCES "SubTypes" ("SubTypeId")
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20220418122152_Init') THEN
    CREATE TABLE "Subscriptions" (
        "SubscriptionId" integer GENERATED BY DEFAULT AS IDENTITY,
        "SubscriptionName" text NOT NULL,
        "SubscriptionTypeSubTypeId" integer NOT NULL,
        CONSTRAINT "PK_Subscriptions" PRIMARY KEY ("SubscriptionId"),
        CONSTRAINT "FK_Subscriptions_SubTypes_SubscriptionTypeSubTypeId" FOREIGN KEY ("SubscriptionTypeSubTypeId") REFERENCES "SubTypes" ("SubTypeId") ON DELETE CASCADE
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20220418122152_Init') THEN
    CREATE TABLE "AspNetUserClaims" (
        "Id" integer GENERATED BY DEFAULT AS IDENTITY,
        "UserId" integer NOT NULL,
        "ClaimType" text NULL,
        "ClaimValue" text NULL,
        CONSTRAINT "PK_AspNetUserClaims" PRIMARY KEY ("Id"),
        CONSTRAINT "FK_AspNetUserClaims_AspNetUsers_UserId" FOREIGN KEY ("UserId") REFERENCES "AspNetUsers" ("Id") ON DELETE CASCADE
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20220418122152_Init') THEN
    CREATE TABLE "AspNetUserLogins" (
        "LoginProvider" text NOT NULL,
        "ProviderKey" text NOT NULL,
        "ProviderDisplayName" text NULL,
        "UserId" integer NOT NULL,
        CONSTRAINT "PK_AspNetUserLogins" PRIMARY KEY ("LoginProvider", "ProviderKey"),
        CONSTRAINT "FK_AspNetUserLogins_AspNetUsers_UserId" FOREIGN KEY ("UserId") REFERENCES "AspNetUsers" ("Id") ON DELETE CASCADE
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20220418122152_Init') THEN
    CREATE TABLE "AspNetUserRoles" (
        "UserId" integer NOT NULL,
        "RoleId" integer NOT NULL,
        CONSTRAINT "PK_AspNetUserRoles" PRIMARY KEY ("UserId", "RoleId"),
        CONSTRAINT "FK_AspNetUserRoles_AspNetRoles_RoleId" FOREIGN KEY ("RoleId") REFERENCES "AspNetRoles" ("Id") ON DELETE CASCADE,
        CONSTRAINT "FK_AspNetUserRoles_AspNetUsers_UserId" FOREIGN KEY ("UserId") REFERENCES "AspNetUsers" ("Id") ON DELETE CASCADE
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20220418122152_Init') THEN
    CREATE TABLE "AspNetUserTokens" (
        "UserId" integer NOT NULL,
        "LoginProvider" text NOT NULL,
        "Name" text NOT NULL,
        "Value" text NULL,
        CONSTRAINT "PK_AspNetUserTokens" PRIMARY KEY ("UserId", "LoginProvider", "Name"),
        CONSTRAINT "FK_AspNetUserTokens_AspNetUsers_UserId" FOREIGN KEY ("UserId") REFERENCES "AspNetUsers" ("Id") ON DELETE CASCADE
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20220418122152_Init') THEN
    CREATE TABLE "Comments" (
        "CommentId" integer GENERATED BY DEFAULT AS IDENTITY,
        "UserId" integer NOT NULL,
        "Text" text NOT NULL,
        "CreatedDate" timestamp with time zone NOT NULL,
        CONSTRAINT "PK_Comments" PRIMARY KEY ("CommentId"),
        CONSTRAINT "FK_Comments_AspNetUsers_UserId" FOREIGN KEY ("UserId") REFERENCES "AspNetUsers" ("Id") ON DELETE CASCADE
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20220418122152_Init') THEN
    CREATE TABLE "CourseUser" (
        "AuthorId" integer NOT NULL,
        "AuthorOfCourseId" integer NOT NULL,
        CONSTRAINT "PK_CourseUser" PRIMARY KEY ("AuthorId", "AuthorOfCourseId"),
        CONSTRAINT "FK_CourseUser_AspNetUsers_AuthorId" FOREIGN KEY ("AuthorId") REFERENCES "AspNetUsers" ("Id") ON DELETE CASCADE,
        CONSTRAINT "FK_CourseUser_Courses_AuthorOfCourseId" FOREIGN KEY ("AuthorOfCourseId") REFERENCES "Courses" ("CourseId") ON DELETE CASCADE
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20220418122152_Init') THEN
    CREATE TABLE "CourseUser1" (
        "CoursesCourseId" integer NOT NULL,
        "UsersId" integer NOT NULL,
        CONSTRAINT "PK_CourseUser1" PRIMARY KEY ("CoursesCourseId", "UsersId"),
        CONSTRAINT "FK_CourseUser1_AspNetUsers_UsersId" FOREIGN KEY ("UsersId") REFERENCES "AspNetUsers" ("Id") ON DELETE CASCADE,
        CONSTRAINT "FK_CourseUser1_Courses_CoursesCourseId" FOREIGN KEY ("CoursesCourseId") REFERENCES "Courses" ("CourseId") ON DELETE CASCADE
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20220418122152_Init') THEN
    CREATE TABLE "Tags" (
        "TagId" integer GENERATED BY DEFAULT AS IDENTITY,
        "TagName" text NOT NULL,
        "CourseId" integer NULL,
        CONSTRAINT "PK_Tags" PRIMARY KEY ("TagId"),
        CONSTRAINT "FK_Tags_Courses_CourseId" FOREIGN KEY ("CourseId") REFERENCES "Courses" ("CourseId")
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20220418122152_Init') THEN
    CREATE TABLE "SubscriptionUser" (
        "SubscriptionsSubscriptionId" integer NOT NULL,
        "UsersId" integer NOT NULL,
        CONSTRAINT "PK_SubscriptionUser" PRIMARY KEY ("SubscriptionsSubscriptionId", "UsersId"),
        CONSTRAINT "FK_SubscriptionUser_AspNetUsers_UsersId" FOREIGN KEY ("UsersId") REFERENCES "AspNetUsers" ("Id") ON DELETE CASCADE,
        CONSTRAINT "FK_SubscriptionUser_Subscriptions_SubscriptionsSubscriptionId" FOREIGN KEY ("SubscriptionsSubscriptionId") REFERENCES "Subscriptions" ("SubscriptionId") ON DELETE CASCADE
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20220418122152_Init') THEN
    CREATE TABLE "Pages" (
        "PageId" integer GENERATED BY DEFAULT AS IDENTITY,
        "Text" text NOT NULL,
        "Movie" text NOT NULL,
        "CommentId" integer NOT NULL,
        "Image" bytea NOT NULL,
        "CourseId" integer NULL,
        CONSTRAINT "PK_Pages" PRIMARY KEY ("PageId"),
        CONSTRAINT "FK_Pages_Comments_CommentId" FOREIGN KEY ("CommentId") REFERENCES "Comments" ("CommentId") ON DELETE CASCADE,
        CONSTRAINT "FK_Pages_Courses_CourseId" FOREIGN KEY ("CourseId") REFERENCES "Courses" ("CourseId")
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20220418122152_Init') THEN
    CREATE INDEX "IX_AspNetRoleClaims_RoleId" ON "AspNetRoleClaims" ("RoleId");
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20220418122152_Init') THEN
    CREATE UNIQUE INDEX "RoleNameIndex" ON "AspNetRoles" ("NormalizedName");
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20220418122152_Init') THEN
    CREATE INDEX "IX_AspNetUserClaims_UserId" ON "AspNetUserClaims" ("UserId");
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20220418122152_Init') THEN
    CREATE INDEX "IX_AspNetUserLogins_UserId" ON "AspNetUserLogins" ("UserId");
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20220418122152_Init') THEN
    CREATE INDEX "IX_AspNetUserRoles_RoleId" ON "AspNetUserRoles" ("RoleId");
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20220418122152_Init') THEN
    CREATE INDEX "EmailIndex" ON "AspNetUsers" ("NormalizedEmail");
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20220418122152_Init') THEN
    CREATE INDEX "IX_AspNetUsers_UserRoleId" ON "AspNetUsers" ("UserRoleId");
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20220418122152_Init') THEN
    CREATE UNIQUE INDEX "UserNameIndex" ON "AspNetUsers" ("NormalizedUserName");
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20220418122152_Init') THEN
    CREATE INDEX "IX_Comments_UserId" ON "Comments" ("UserId");
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20220418122152_Init') THEN
    CREATE INDEX "IX_Courses_StatusId" ON "Courses" ("StatusId");
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20220418122152_Init') THEN
    CREATE INDEX "IX_Courses_SubTypeId" ON "Courses" ("SubTypeId");
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20220418122152_Init') THEN
    CREATE INDEX "IX_CourseUser_AuthorOfCourseId" ON "CourseUser" ("AuthorOfCourseId");
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20220418122152_Init') THEN
    CREATE INDEX "IX_CourseUser1_UsersId" ON "CourseUser1" ("UsersId");
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20220418122152_Init') THEN
    CREATE INDEX "IX_Pages_CommentId" ON "Pages" ("CommentId");
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20220418122152_Init') THEN
    CREATE INDEX "IX_Pages_CourseId" ON "Pages" ("CourseId");
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20220418122152_Init') THEN
    CREATE INDEX "IX_Subscriptions_SubscriptionTypeSubTypeId" ON "Subscriptions" ("SubscriptionTypeSubTypeId");
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20220418122152_Init') THEN
    CREATE INDEX "IX_SubscriptionUser_UsersId" ON "SubscriptionUser" ("UsersId");
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20220418122152_Init') THEN
    CREATE INDEX "IX_Tags_CourseId" ON "Tags" ("CourseId");
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20220418122152_Init') THEN
    INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
    VALUES ('20220418122152_Init', '6.0.4');
    END IF;
END $EF$;
COMMIT;

START TRANSACTION;


DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20220418123005_TestForDeletingCU1') THEN
    ALTER TABLE "CourseUser" DROP CONSTRAINT "FK_CourseUser_AspNetUsers_AuthorId";
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20220418123005_TestForDeletingCU1') THEN
    ALTER TABLE "CourseUser" DROP CONSTRAINT "FK_CourseUser_Courses_AuthorOfCourseId";
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20220418123005_TestForDeletingCU1') THEN
    DROP TABLE "CourseUser1";
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20220418123005_TestForDeletingCU1') THEN
    ALTER TABLE "CourseUser" RENAME COLUMN "AuthorOfCourseId" TO "UsersId";
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20220418123005_TestForDeletingCU1') THEN
    ALTER TABLE "CourseUser" RENAME COLUMN "AuthorId" TO "CoursesCourseId";
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20220418123005_TestForDeletingCU1') THEN
    ALTER INDEX "IX_CourseUser_AuthorOfCourseId" RENAME TO "IX_CourseUser_UsersId";
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20220418123005_TestForDeletingCU1') THEN
    CREATE TABLE "AuthorOfCourse" (
        "AuthorId" integer NOT NULL,
        "AuthorOfCourseId" integer NOT NULL,
        CONSTRAINT "PK_AuthorOfCourse" PRIMARY KEY ("AuthorId", "AuthorOfCourseId"),
        CONSTRAINT "FK_AuthorOfCourse_AspNetUsers_AuthorId" FOREIGN KEY ("AuthorId") REFERENCES "AspNetUsers" ("Id") ON DELETE CASCADE,
        CONSTRAINT "FK_AuthorOfCourse_Courses_AuthorOfCourseId" FOREIGN KEY ("AuthorOfCourseId") REFERENCES "Courses" ("CourseId") ON DELETE CASCADE
    );
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20220418123005_TestForDeletingCU1') THEN
    CREATE INDEX "IX_AuthorOfCourse_AuthorOfCourseId" ON "AuthorOfCourse" ("AuthorOfCourseId");
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20220418123005_TestForDeletingCU1') THEN
    ALTER TABLE "CourseUser" ADD CONSTRAINT "FK_CourseUser_AspNetUsers_UsersId" FOREIGN KEY ("UsersId") REFERENCES "AspNetUsers" ("Id") ON DELETE CASCADE;
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20220418123005_TestForDeletingCU1') THEN
    ALTER TABLE "CourseUser" ADD CONSTRAINT "FK_CourseUser_Courses_CoursesCourseId" FOREIGN KEY ("CoursesCourseId") REFERENCES "Courses" ("CourseId") ON DELETE CASCADE;
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20220418123005_TestForDeletingCU1') THEN
    INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
    VALUES ('20220418123005_TestForDeletingCU1', '6.0.4');
    END IF;
END $EF$;
COMMIT;

START TRANSACTION;


DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20220429210507_AuthV1.3') THEN
    ALTER TABLE "AspNetRoles" DROP COLUMN "RoleId";
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20220429210507_AuthV1.3') THEN
    ALTER TABLE "AspNetRoles" ALTER COLUMN "Name" DROP NOT NULL;
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20220429210507_AuthV1.3') THEN
    INSERT INTO "AspNetRoles" ("Id", "ConcurrencyStamp", "Name", "NormalizedName")
    VALUES (1, 'd0876391-25e9-43fc-a25b-376b37d0bf33', 'defaultUser', NULL);
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20220429210507_AuthV1.3') THEN
    PERFORM setval(
        pg_get_serial_sequence('"AspNetRoles"', 'Id'),
        GREATEST(
            (SELECT MAX("Id") FROM "AspNetRoles") + 1,
            nextval(pg_get_serial_sequence('"AspNetRoles"', 'Id'))),
        false);
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20220429210507_AuthV1.3') THEN
    INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
    VALUES ('20220429210507_AuthV1.3', '6.0.4');
    END IF;
END $EF$;
COMMIT;

START TRANSACTION;


DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20220429210825_AuthV1.4') THEN
    UPDATE "AspNetRoles" SET "ConcurrencyStamp" = '4642e85f-9114-4fef-a502-636bc9b651af', "NormalizedName" = 'DEFAULTUSER'
    WHERE "Id" = 1;
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20220429210825_AuthV1.4') THEN
    INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
    VALUES ('20220429210825_AuthV1.4', '6.0.4');
    END IF;
END $EF$;
COMMIT;

START TRANSACTION;


DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20220429220144_AuthV1.5') THEN
    ALTER TABLE "AspNetUsers" DROP CONSTRAINT "FK_AspNetUsers_AspNetRoles_UserRoleId";
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20220429220144_AuthV1.5') THEN
    DROP INDEX "IX_AspNetUsers_UserRoleId";
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20220429220144_AuthV1.5') THEN
    DELETE FROM "AspNetRoles"
    WHERE "Id" = 1;
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20220429220144_AuthV1.5') THEN
    ALTER TABLE "AspNetUsers" DROP COLUMN "UserRoleId";
    END IF;
END $EF$;

DO $EF$
BEGIN
    IF NOT EXISTS(SELECT 1 FROM "__EFMigrationsHistory" WHERE "MigrationId" = '20220429220144_AuthV1.5') THEN
    INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
    VALUES ('20220429220144_AuthV1.5', '6.0.4');
    END IF;
END $EF$;
COMMIT;

