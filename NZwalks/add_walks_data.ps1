# PowerShell script to add sample walks data
# Make sure the backend API is running on http://localhost:5068

$baseUrl = "http://localhost:5068/api/walks"

# Sample walks data
$walks = @(
    @{
        name = "Tongariro Alpine Crossing"
        description = "A challenging day hike through volcanic terrain with stunning views of Mount Ngauruhoe and Mount Tongariro."
        lengthInKm = 19.4
        walkImageUrl = "https://images.unsplash.com/photo-1551632811-561732d1e306?w=800"
        difficulityId = "c5bcc8c6-aabb-4e02-89fe-d995e6b2ab9d"
        regionId = "607ebf8f-c366-44e2-b179-b013032e6d89"
    },
    @{
        name = "Milford Track"
        description = "One of New Zealand's most famous walks, featuring stunning fiords, waterfalls, and alpine scenery."
        lengthInKm = 53.5
        walkImageUrl = "https://images.unsplash.com/photo-1506905925346-21bda4d32df4?w=800"
        difficulityId = "c5bcc8c6-aabb-4e02-89fe-d995e6b2ab9d"
        regionId = "aa4c7097-4c1b-4521-8864-2af5f4ca738d"
    },
    @{
        name = "Abel Tasman Coast Track"
        description = "A beautiful coastal walk with golden beaches, clear waters, and lush native forest."
        lengthInKm = 60.0
        walkImageUrl = "https://images.unsplash.com/photo-1441974231531-c6227db76b6e?w=800"
        difficulityId = "3535f08a-e81b-4b43-8a0a-14a525b9b9d8"
        regionId = "aa4c7097-4c1b-4521-8864-2af5f4ca738d"
    },
    @{
        name = "Routeburn Track"
        description = "A spectacular alpine walk connecting Mount Aspiring and Fiordland National Parks."
        lengthInKm = 32.0
        walkImageUrl = "https://images.unsplash.com/photo-1464822759844-d150baec0134?w=800"
        difficulityId = "c5bcc8c6-aabb-4e02-89fe-d995e6b2ab9d"
        regionId = "aa4c7097-4c1b-4521-8864-2af5f4ca738d"
    },
    @{
        name = "Coromandel Coastal Walkway"
        description = "A scenic coastal walk with stunning views of the Pacific Ocean and Coromandel Peninsula."
        lengthInKm = 8.0
        walkImageUrl = "https://images.unsplash.com/photo-1506905925346-21bda4d32df4?w=800"
        difficulityId = "2e503a55-8cd6-4002-887b-8d8d025211bf"
        regionId = "607ebf8f-c366-44e2-b179-b013032e6d89"
    },
    @{
        name = "Rakiura Track"
        description = "A peaceful walk through native forest and along beautiful beaches on Stewart Island."
        lengthInKm = 32.0
        walkImageUrl = "https://images.unsplash.com/photo-1441974231531-c6227db76b6e?w=800"
        difficulityId = "3535f08a-e81b-4b43-8a0a-14a525b9b9d8"
        regionId = "aa4c7097-4c1b-4521-8864-2af5f4ca738d"
    },
    @{
        name = "Kepler Track"
        description = "A spectacular loop track featuring alpine tussock, beech forest, and lake views."
        lengthInKm = 60.0
        walkImageUrl = "https://images.unsplash.com/photo-1464822759844-d150baec0134?w=800"
        difficulityId = "3535f08a-e81b-4b43-8a0a-14a525b9b9d8"
        regionId = "aa4c7097-4c1b-4521-8864-2af5f4ca738d"
    },
    @{
        name = "Tongariro Northern Circuit"
        description = "A multi-day walk around Mount Ngauruhoe with volcanic landscapes and alpine meadows."
        lengthInKm = 43.1
        walkImageUrl = "https://images.unsplash.com/photo-1551632811-561732d1e306?w=800"
        difficulityId = "c5bcc8c6-aabb-4e02-89fe-d995e6b2ab9d"
        regionId = "607ebf8f-c366-44e2-b179-b013032e6d89"
    }
)

Write-Host "Adding sample walks data to the database..."
Write-Host "Make sure the backend API is running on http://localhost:5068"
Write-Host ""

foreach ($walk in $walks) {
    try {
        $json = $walk | ConvertTo-Json
        Write-Host "Adding walk: $($walk.name)"
        
        $response = Invoke-RestMethod -Uri $baseUrl -Method POST -Body $json -ContentType "application/json"
        Write-Host "Successfully added: $($walk.name)" -ForegroundColor Green
    }
    catch {
        Write-Host "Error adding walk $($walk.name): $($_.Exception.Message)" -ForegroundColor Red
    }
}

Write-Host ""
Write-Host "Finished adding walks data!"
Write-Host "You can now check the frontend to see the walks." 