-- Seed Walks Data
-- This script adds sample walks to the database

-- Insert sample walks
INSERT INTO Walks (Id, Name, Description, LengthInKm, WalkImageUrl, DifficulityId, RegionId)
VALUES 
    (NEWID(), 'Tongariro Alpine Crossing', 'A challenging day hike through volcanic terrain with stunning views of Mount Ngauruhoe and Mount Tongariro.', 19.4, 'https://images.unsplash.com/photo-1551632811-561732d1e306?w=800', 'c5bcc8c6-aabb-4e02-89fe-d995e6b2ab9d', '607ebf8f-c366-44e2-b179-b013032e6d89'),
    
    (NEWID(), 'Milford Track', 'One of New Zealand''s most famous walks, featuring stunning fiords, waterfalls, and alpine scenery.', 53.5, 'https://images.unsplash.com/photo-1506905925346-21bda4d32df4?w=800', 'c5bcc8c6-aabb-4e02-89fe-d995e6b2ab9d', 'aa4c7097-4c1b-4521-8864-2af5f4ca738d'),
    
    (NEWID(), 'Abel Tasman Coast Track', 'A beautiful coastal walk with golden beaches, clear waters, and lush native forest.', 60.0, 'https://images.unsplash.com/photo-1441974231531-c6227db76b6e?w=800', '3535f08a-e81b-4b43-8a0a-14a525b9b9d8', 'aa4c7097-4c1b-4521-8864-2af5f4ca738d'),
    
    (NEWID(), 'Routeburn Track', 'A spectacular alpine walk connecting Mount Aspiring and Fiordland National Parks.', 32.0, 'https://images.unsplash.com/photo-1464822759844-d150baec0134?w=800', 'c5bcc8c6-aabb-4e02-89fe-d995e6b2ab9d', 'aa4c7097-4c1b-4521-8864-2af5f4ca738d'),
    
    (NEWID(), 'Coromandel Coastal Walkway', 'A scenic coastal walk with stunning views of the Pacific Ocean and Coromandel Peninsula.', 8.0, 'https://images.unsplash.com/photo-1506905925346-21bda4d32df4?w=800', '2e503a55-8cd6-4002-887b-8d8d025211bf', '607ebf8f-c366-44e2-b179-b013032e6d89'),
    
    (NEWID(), 'Rakiura Track', 'A peaceful walk through native forest and along beautiful beaches on Stewart Island.', 32.0, 'https://images.unsplash.com/photo-1441974231531-c6227db76b6e?w=800', '3535f08a-e81b-4b43-8a0a-14a525b9b9d8', 'aa4c7097-4c1b-4521-8864-2af5f4ca738d'),
    
    (NEWID(), 'Kepler Track', 'A spectacular loop track featuring alpine tussock, beech forest, and lake views.', 60.0, 'https://images.unsplash.com/photo-1464822759844-d150baec0134?w=800', '3535f08a-e81b-4b43-8a0a-14a525b9b9d8', 'aa4c7097-4c1b-4521-8864-2af5f4ca738d'),
    
    (NEWID(), 'Tongariro Northern Circuit', 'A multi-day walk around Mount Ngauruhoe with volcanic landscapes and alpine meadows.', 43.1, 'https://images.unsplash.com/photo-1551632811-561732d1e306?w=800', 'c5bcc8c6-aabb-4e02-89fe-d995e6b2ab9d', '607ebf8f-c366-44e2-b179-b013032e6d89');

-- Note: The GUIDs for DifficulityId and RegionId are from the existing seeded data
-- Easy: 2e503a55-8cd6-4002-887b-8d8d025211bf
-- Medium: 3535f08a-e81b-4b43-8a0a-14a525b9b9d8  
-- Hard: c5bcc8c6-aabb-4e02-89fe-d995e6b2ab9d
-- North Island: 607ebf8f-c366-44e2-b179-b013032e6d89
-- South Island: aa4c7097-4c1b-4521-8864-2af5f4ca738d 