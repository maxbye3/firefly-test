-- Write the SQL create statements for staff members attending meetings
CREATE TABLE meetings (
  id SERIAL PRIMARY KEY
);

CREATE TYPE member_type AS ENUM ('manager', 'ordinary');
CREATE TABLE members (
  id SERIAL PRIMARY KEY,
  type member_type
);

CREATE TABLE meetings_members (
  meeting_id INT NOT NULL,
  member_id INT NOT NULL,
  PRIMARY KEY(meeting_id, member_id),
  
  FOREIGN KEY (meeting_id) 
  REFERENCES meetings(id) 
  ON DELETE CASCADE,
  
  FOREIGN KEY (member_id) 
  REFERENCES members(id) 
  ON DELETE CASCADE

  s);

-- Create an SQL query, based on your create statements, that returns the number of meetings which have been attended by Managers only.
SELECT COUNT(1) 
AS manager_meetings 
FROM meetings 
WHERE id NOT IN (
	SELECT meeting_id 
	FROM meetings_members 
	JOIN members 
	WHERE members.type != 'manager' 
	GROUP BY meeting_id
);


