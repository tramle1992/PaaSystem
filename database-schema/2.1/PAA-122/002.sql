
--- Update permission for role

update [user] set role_id = (select role_id from [role] where role_name = 'Administrator') WHERE [username] = 'Matt';
update role_feature_permission set is_allowed = 'true' where role_id in (SELECT role_id from role where role_name = 'Administrator');
update role_feature_permission set is_allowed = 'true' where role_id in (SELECT role_id from role where role_name = 'Executive');
update role_feature_permission set is_allowed = 'true' where role_id in (SELECT role_id from role where role_name = 'Reviewer') AND feature_id in (select feature_id from feature_permission where feature_name in ('Auto Document','View Client Info','View Explore App','Add/Edit Review Comment','Archive Apps','View Info Resources'));
update role_feature_permission set is_allowed = 'true' where role_id in (SELECT role_id from role where role_name = 'Screener') AND feature_id in (select feature_id from feature_permission where feature_name in ('Auto Document','View Client Info','View Explore App','View Info Resources'));