

-- Test: Confirm new member registration inserted correctly

SELECT * FROM Member ORDER BY MemberID DESC;


-- Test: Confirm Sign In matches an existing member's credentials

SELECT * FROM Member WHERE MemberEmail = 'samidhi@email.com' AND MemberPassword = 'password555';
